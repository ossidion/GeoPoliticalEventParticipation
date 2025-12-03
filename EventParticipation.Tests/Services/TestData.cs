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

        public static List<Organization> GetOrganizations()
        {
            return new List<Organization>
            {
                new Organization { Id = 1, Name = "UNICEF", OrgType = "UN Agency" },
                new Organization { Id = 2, Name = "WHO", OrgType = "UN Agency" },
                new Organization { Id = 3, Name = "Red Cross", OrgType = "NGO" },
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

        public static List<Participation> GetParticipations()
        {
            var countries = GetCountries();
            var organizations = GetOrganizations();
            var events = GetEvents();

            return new List<Participation>
            {
                new Participation { Id = 1, Country = countries[0], Organization = organizations[0], Event = events[0] }, // UK - UNICEF - Global Health
                new Participation { Id = 2, Country = countries[1], Organization = organizations[1], Event = events[0] }, // France - WHO - Global Health
                new Participation { Id = 3, Country = countries[0], Organization = organizations[1], Event = events[1] }, // UK - WHO - Climate
                new Participation { Id = 4, Country = countries[2], Organization = organizations[2], Event = events[1] }, // Germany - Red Cross - Climate
                new Participation { Id = 5, Country = countries[1], Organization = organizations[0], Event = events[2] }, // France - UNICEF - Peace
                new Participation { Id = 6, Country = countries[2], Organization = organizations[1], Event = events[2] }, // Germany - WHO - Peace
            };
        }
    }
}
