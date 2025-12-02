using Xunit;
using System;
using System.Collections.Generic;
using EventParticipation.Api.Models;
using EventParticipation.Api.Services;
using EventParticipation.Tests.Services;

namespace EventParticipation.Tests.Services
{
    public class MetricServiceTests
    {
        private readonly List<Participation> _participations;
        private readonly MetricService _metricService;

        public MetricServiceTests()
        {
            _participations = TestData.GetParticipations();
            _metricService = new MetricService(_participations);
        }

        [Fact]
        public void GetCountryParticipationCounts_ReturnsCorrectCounts()
        {
            var result = _metricService.GetCountryParticipationCounts();

            Assert.Equal(2, result["United Kingdom"]);
            Assert.Equal(2, result["France"]);
            Assert.Equal(1, result["Germany"]);
            Assert.Equal(1, result["United States"]);
        }

        [Fact]
        public void GetEventParticipationCounts_ReturnsCorrectCounts()
        {
            var result = _metricService.GetEventParticipationReach();

            var event1 = result["Global Health Summit"];
            Assert.Equal(2, event1.UniqueCountries);
            Assert.Equal(2, event1.UniqueOrganizations);

            var event2 = result["Climate Action Forum"];
            Assert.Equal(2, event2.UniqueCountries);
            Assert.Equal(2, event2.UniqueOrganizations);

            var event3 = result["Peace and Security Conference"];
            Assert.Equal(2, event3.UniqueCountries);
            Assert.Equal(2, event3.UniqueOrganizations);
        }

    }
}