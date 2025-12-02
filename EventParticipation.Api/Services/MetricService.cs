using EventParticipation.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventParticipation.Api.Services

{
    public class EventReach
    {
        public int UniqueCountries { get; set; }
        public int UniqueOrganizations { get; set; }
    }

    public class MetricService
    {
        private readonly List<Participation> _participations;

        public MetricService(List<Participation> participations) 
        { 
        _participations = participations;
        }

        public Dictionary<string, int> GetCountryParticipationCounts()
        {
            return _participations
                .GroupBy(p => p.Country.Name)
                .ToDictionary(g => g.Key, g => g.Count());
        }


        public Dictionary<string, EventReach> GetEventParticipationReach()
        {
            return _participations
                .GroupBy(p => p.Event.Name)
                .ToDictionary(
                g => g.Key,
                g => new EventReach
                {
                    UniqueCountries = g.Select(p => p.Country.Name).Distinct().Count(),
                    UniqueOrganizations = g.Select(p => p.Organization.Name).Distinct().Count()
                }
            );
        }


        public Task<Dictionary<string, int>> GetCountryParticipationCountAsync()
        {
            return Task.FromResult(GetCountryParticipationCounts());
        }

        public Task<Dictionary<string, EventReach>> GetEventParticipationReachAsync()
        {
            return Task.FromResult(GetEventParticipationReach());
        }
    }
}
