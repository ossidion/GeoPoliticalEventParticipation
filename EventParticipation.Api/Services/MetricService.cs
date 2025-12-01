using EventParticipation.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventParticipation.Api.Services

{
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
    }
}
