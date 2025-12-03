using Xunit;
using System;
using System.Collections.Generic;
using EventParticipation.Api.Models;
using EventParticipation.Api.Services;
using EventParticipation.Tests.Services;
using System.Linq;


namespace EventParticipation.Tests.Services
{
    public class MetricServiceTests
    {
        private readonly List<Participation> _participations;
        private readonly MetricServiceFake _metricService;

        public MetricServiceTests()
        {
            _participations = TestData.GenerateParticipations();
            _metricService = new MetricServiceFake(_participations);
        }

        [Fact]
        public async Task GetCountryParticipationCounts_ReturnsCorrectCounts()
        {
            var result = await _metricService.GetCountryParticipationCountAsync();

            var uk = result.First(r => r.Country == "United Kingdom");
            var france = result.First(r => r.Country == "France");
            var germany = result.First(r => r.Country == "Germany");

            Assert.Equal(2, uk.Count);
            Assert.Equal(2, france.Count);
            Assert.Equal(2, germany.Count);
        }


        [Fact]
        public async Task GetEventParticipationCounts_ReturnsCorrectCounts()
        {
            var result = await _metricService.GetEventParticipationReachAsync();

            var event1 = result.First(r => r.Event == "Global Health Summit");
            Assert.Equal(2, event1.UniqueCountries);
            Assert.Equal(2, event1.UniqueOrganizations);

            var event2 = result.First(r => r.Event == "Climate Action Forum");
            Assert.Equal(2, event2.UniqueCountries);
            Assert.Equal(2, event2.UniqueOrganizations);

            var event3 = result.First(r => r.Event == "Peace Conference");
            Assert.Equal(2, event3.UniqueCountries);
            Assert.Equal(2, event3.UniqueOrganizations);
        }

        [Fact]
        public async Task GetCountryCollaborationScore_ReturnsCorrectScores()
        {
            var result = await _metricService.GetCountryCollaborationScoreAsync();

            var uk = result.First(r => r.Country == "United Kingdom");
            var france = result.First(r => r.Country == "France");
            var germany = result.First(r => r.Country == "Germany");

            Assert.Equal(1, uk.Score);
            Assert.Equal(1, france.Score);
            Assert.Equal(1, germany.Score);
        }

    }
}