using EventParticipation.Api.Models;
using System;
using System.Collections.Generic;

namespace EventParticipation.Tests.Services
{
    public static class TestData
    {
        public static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country { Id = 1, Name = "United Kingdom", Region = "Europe", GDP = 3100, Population = 68 },
                new Country { Id = 2, Name = "France", Region = "Europe", GDP = 2800, Population = 65 },
                new Country { Id = 3, Name = "Germany", Region = "Europe", GDP = 4200, Population = 83 },
            };
        }

        public static List<Organisation> GetOrganisations()
        {
            return new List<Organisation>
            {
                new Organisation { Id = 1, Name = "UNICEF", OrgType = "UN Agency" },
                new Organisation { Id = 2, Name = "WHO", OrgType = "UN Agency" },
                new Organisation { Id = 3, Name = "Red Cross", OrgType = "NGO" },
            };
        }

        public static List<Event> GetEvents()
        {
            return new List<Event>
            {
                new Event { Id = 1, Name = "Global Health Summit", Date = new DateTime(2023, 1, 15), Category = "Health" },
                new Event { Id = 2, Name = "Climate Action Forum", Date = new DateTime(2023, 3, 10), Category = "Climate" },
                new Event { Id = 3, Name = "Peace Conference", Date = new DateTime(2023, 5, 5), Category = "Security" },
            };
        }

        public static List<Participation> GenerateParticipations()
        {
            var countries = GetCountries();
            var organizations = GetOrganisations();
            var events = GetEvents();

            return new List<Participation>
            {
                new Participation { Id = 1, Country = countries[0], Organisation = organizations[0], Event = events[0] }, // UK - UNICEF - Global Health
                new Participation { Id = 2, Country = countries[1], Organisation = organizations[1], Event = events[0] }, // France - WHO - Global Health
                new Participation { Id = 3, Country = countries[0], Organisation = organizations[1], Event = events[1] }, // UK - WHO - Climate
                new Participation { Id = 4, Country = countries[2], Organisation = organizations[2], Event = events[1] }, // Germany - Red Cross - Climate
                new Participation { Id = 5, Country = countries[1], Organisation = organizations[0], Event = events[2] }, // France - UNICEF - Peace
                new Participation { Id = 6, Country = countries[2], Organisation = organizations[1], Event = events[2] }, // Germany - WHO - Peace
            };
        }

        // Trend test data

        public static List<Event> GetTrendEvents()
        {
            return new List<Event>
            {
            // Previous period (2023)
            new Event { Id = 101, Name = "Global Health Summit 2023", Date = new DateTime(2023, 1, 15), Category = "Health" },
            new Event { Id = 102, Name = "Climate Action Forum 2023", Date = new DateTime(2023, 6, 10), Category = "Climate" },
            new Event { Id = 103, Name = "Peace Conference 2023", Date = new DateTime(2023, 11, 5), Category = "Security" },

            // Current period (2024)
            new Event { Id = 104, Name = "Sustainable Energy Forum 2024", Date = new DateTime(2024, 2, 20), Category = "Energy" },
            new Event { Id = 105, Name = "Global Health Update 2024", Date = new DateTime(2024, 5, 15), Category = "Health" },
            new Event { Id = 106, Name = "Peace and Security Summit 2024", Date = new DateTime(2024, 9, 10), Category = "Security" },
            };
        }

        public static List<Participation> GenerateTrendParticipations()
        {
            var countries = TestData.GetCountries();
            var organizations = TestData.GetOrganisations();
            var events = GetTrendEvents();

            return new List<Participation>
            {
            // Previous period (2023)
            new Participation { Id = 101, Country = countries[0], Organisation = organizations[0], Event = events[0] }, // UK
            new Participation { Id = 102, Country = countries[0], Organisation = organizations[1], Event = events[1] }, // UK
            new Participation { Id = 103, Country = countries[1], Organisation = organizations[0], Event = events[2] }, // France

            // Current period (2024)
            new Participation { Id = 104, Country = countries[0], Organisation = organizations[1], Event = events[3] }, // UK
            new Participation { Id = 105, Country = countries[1], Organisation = organizations[0], Event = events[4] }, // France
            new Participation { Id = 106, Country = countries[1], Organisation = organizations[1], Event = events[5] }, // France
            };
        }
    }
}
