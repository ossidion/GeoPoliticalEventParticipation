using EventParticipation.Api.Data;
using EventParticipation.Api.Models;
using Microsoft.EntityFrameworkCore;
using EventParticipation.Api.DTOs;

namespace EventParticipation.Api.Services

{
    public class MetricService
    {
        private readonly AppDbContext _context;

        public MetricService(AppDbContext context)
        { 
            _context = context;
        }

        public Task<List<CountryParticipationDto>> GetCountryParticipationCountAsync()
        {
            var result = _context.Participations
                .GroupBy(p => p.Country.Name)
                .Select(g => new CountryParticipationDto
                {
                    Country = g.Key,
                    Count = g.Count()
                })
                .ToList();

            return Task.FromResult(result);
        }

        public Task<List<EventParticipationReachDto>> GetEventParticipationReachAsync()
        {
            var result = _context.Participations
                .GroupBy(p => p.Event.Name)
                .Select(g => new EventParticipationReachDto
                {
                    Event = g.Key,
                    UniqueCountries = g.Select(p => p.Country.Name).Distinct().Count(),
                    UniqueOrganizations = g.Select(p => p.Organisation.Name).Distinct().Count()
                })
                .ToList();

            return Task.FromResult(result);
        }

        public Task<List<CountryCollaborationDto>> GetCountryCollaborationScoreAsync()
        {
            var result = _context.Participations
                .GroupBy(p => p.Country.Name)
                .Select(g => new CountryCollaborationDto
                {
                    Country = g.Key,
                    Score = g.Select(p => p.Organisation.Id)   // select all org IDs
                             .Distinct()                     // get unique IDs
                             .Count() / (double)g.Count()   // divide by total participations
                })
                .ToList();

            return Task.FromResult(result);
        }

        public async Task<List<OrganisationInflucenceDto>> GetOrganisationInfluenceIndexAsync()
        {
            var result = _context.Participations
                .GroupBy(p => p.Organisation.Id)
                .Select(g => new OrganisationInflucenceDto
                {
                    Organisation = g.First().Organisation.Name,
                    Score = g
                        .GroupBy(p => p.Event.Id)
                        .Select(eventGroup => eventGroup
                            .Select(part => part.Country.Id)
                            .Distinct()
                            .Count()
                        )
                        .Sum()
                })
                .OrderByDescending(p => p.Score)
                .ToList();

            return await Task.FromResult(result);
        }

        public async Task<List<CountryTrendDto>> GetCountryEmergingTrendAsync(DateTime windowStart, DateTime windowEnd)
        {
            var participations = await _context.Participations
                .Include(p => p.Country)
                .Include(p => p.Event)
                .ToListAsync();

            var result = participations
                .GroupBy(p => p.Country.Name)
                .Select(g =>
                {
                    var previousCount = g.Count(p => p.Event.Date < windowStart);
                    var currentCount = g.Count(p => p.Event.Date >= windowStart && p.Event.Date <= windowEnd);
                    var totalCount = g.Count();
                    var trendScore = ((double)currentCount / totalCount - ((double)previousCount / totalCount)); // Normalise

                    return new CountryTrendDto
                    {
                        Country = g.Key,
                        CurrentPeriodCount = currentCount,
                        PreviousPeriodCount = previousCount,
                        TrendScore = trendScore
                    };
                })
                .OrderByDescending(p => p.TrendScore)
                .ToList();

            return await Task.FromResult(result);
        }
    }
}
