using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventParticipation.Api.Models;

namespace EventParticipation.Tests.Services
{
    public class MetricServiceFake
    {
        private readonly List<Participation> _participations;

        public MetricServiceFake(List<Participation> participations)
        {
            _participations = participations;
        }

        public Task<List<CountryParticipationDto>> GetCountryParticipationCountAsync()
        {
            var result = _participations
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
            var result = _participations
                .GroupBy(p => p.Event.Name)
                .Select(g => new EventParticipationReachDto
                {
                    Event = g.Key,
                    UniqueCountries = g.Select(p => p.Country.Name).Distinct().Count(),
                    UniqueOrganizations = g.Select(p => p.Organization.Name).Distinct().Count()
                })
                .ToList();

            return Task.FromResult(result);
        }

        public Task<List<CountryCollaborationDto>> GetCountryCollaborationScoreAsync()
        {
            var result = _participations
                .GroupBy(p => p.Country.Name)
                .Select(g => new CountryCollaborationDto
                {
                    Country = g.Key,
                    Score = g.Select(p => p.Organization.Id)   // select all org IDs
                             .Distinct()                     // get unique IDs
                             .Count() / (double)g.Count()   // divide by total participations
                })
                .ToList();

            return Task.FromResult(result);
        }




        // -------------------------------
        // DTOs for testing
        // -------------------------------
        public class CountryParticipationDto
        {
            public string Country { get; set; } = string.Empty;
            public int Count { get; set; }
        }

        public class EventParticipationReachDto
        {
            public string Event { get; set; } = string.Empty;
            public int UniqueCountries { get; set; }
            public int UniqueOrganizations { get; set; }
        }

        public class CountryCollaborationDto
        {
            public string Country { get; set; } = string.Empty;
            public double Score { get; set; }
        }
    }
}
