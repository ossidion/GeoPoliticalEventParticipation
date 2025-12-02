using EventParticipation.Api.Data;
using EventParticipation.Api.Models;
using Microsoft.EntityFrameworkCore;
using EventParticipation.Api.DTOs;

namespace EventParticipation.Api.Services

{
    public class EventReach
    {
        public int UniqueCountries { get; set; }
        public int UniqueOrganizations { get; set; }
    }

    public class MetricService
    {
        private readonly AppDbContext _context;

        public MetricService(AppDbContext context)
        { 
            _context = context;
        }

        public async Task<List<CountryParticipationDto>> GetCountryParticipationCountAsync()
        {
            return await _context.Participations
                .GroupBy(p => p.Country.Name)
                .Select(g => new CountryParticipationDto
                {
                    Country = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();
        }


        public async Task<List<EventParticipationReachDto>> GetEventParticipationReachAsync()
        {
            return await _context.Participations
                .GroupBy(p => p.Event.Name)
                .Select(g => new EventParticipationReachDto
                {
                    Event = g.Key,
                    UniqueCountries = g.Select(p => p.Country.Name).Distinct().Count(),
                    UniqueOrganizations = g.Select(p => p.Organization.Name).Distinct().Count()
                })
                .ToListAsync();
        }
    }
}
