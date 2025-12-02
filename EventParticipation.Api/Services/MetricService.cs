using EventParticipation.Api.Data;
using EventParticipation.Api.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Dictionary<string, int>> GetCountryParticipationCountAsync()
        {
            return await _context.Participations
                .Include(p => p.Country)
                .GroupBy(p => p.Country.Name)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }


        public async Task<Dictionary<string, EventReach>> GetEventParticipationReachAsync()
        {
            var participations = await _context.Participations
                .Include(p => p.Country)
                .Include(p => p.Organization)
                .Include(participations => participations.Event)
                .ToListAsync();

            return participations
                .GroupBy(participations => participations.Event.Name)
                .ToDictionary(
                g => g.Key,
                g => new EventReach
                {
                    UniqueCountries = g.Select(p => p.Country.Name).Distinct().Count(),
                    UniqueOrganizations = g.Select(p => p.Organization.Name).Distinct().Count()
                });
        }
    }
}
