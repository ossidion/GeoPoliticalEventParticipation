using Xunit;
using System;
using System.Collections.Generic;
using EventParticipation.Api.Models;
using EventParticipation.Api.Services;

namespace EventParticipation.Tests.Services
{
    public class MetricServiceTests
    {
        [Fact]
        public void GetCountryParticipationCounts_ReturnsCorrectCounts()
        {
            var france = new Country { Name = "France" };
            var germany = new Country { Name = "Germany" };
            var undp = new Organization { name = "UNDP" };
            var redCross = new Organization { name = "Red Cross" };
            var ev1 = new Event { Name = "Climate Summit 2024", Date = DateTime.Now };

            var participations = new List<Participation>
            {
                new Participation {Country = france, Organization = undp, EventArgs = ev1 },
                new Participation {Country = germany, Organization = redCross, EventArgs = ev1 },
                new Participation {Country = france, Organization = redCross, EventArgs = ev1 }
            };
            var service = new MetricService(participations);

            var result = service.GetCountryParticipationCounts();

            Assert.Equal(2, result["France"]);
            Assert.Equal(1, result["Germany"]);
        }
    }
}