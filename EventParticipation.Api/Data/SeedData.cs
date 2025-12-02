using EventParticipation.Api.Models;

namespace EventParticipation.Api.Data
{
    public static class SeedData
    {
        public static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country { Id = 1, Name = "United Kingdom" },
                new Country { Id = 2, Name = "France" },
                new Country { Id = 3, Name = "Germany" },
                new Country { Id = 4, Name = "United States" },
                new Country { Id = 5, Name = "Canada" },
                new Country { Id = 6, Name = "Australia" }
            };
        }

        public static List<Organization> GetOrganizations()
        {
            return new List<Organization>
            {
                new Organization { Id = 1, Name = "UNICEF" },
                new Organization { Id = 2, Name = "WHO" },
                new Organization { Id = 3, Name = "Red Cross" },
                new Organization { Id = 4, Name = "FCDO" },
                new Organization { Id = 5, Name = "Amnesty International" }
            };
        }

        public static List<Event> GetEvents()
        {
            return new List<Event>
            {
                new Event { Id = 1, Name = "Global Health Summit" },
                new Event { Id = 2, Name = "Climate Action Forum" },
                new Event { Id = 3, Name = "Peace and Security Conference" }
            };
        }

        public static List<Participation> GetParticipations()
        {
            var countries = GetCountries();
            var organizations = GetOrganizations();
            var events = GetEvents();

            return new List<Participation>
            {
                new Participation { Id = 1, Country = countries[0], Organization = organizations[0], Event = events[0] }, // UK - UNICEF - Global Health Summit
                new Participation { Id = 2, Country = countries[1], Organization = organizations[1], Event = events[0] }, // France - WHO - Global Health Summit
                new Participation { Id = 3, Country = countries[2], Organization = organizations[2], Event = events[1] }, // Germany - Red Cross - Climate Action Forum
                new Participation { Id = 4, Country = countries[0], Organization = organizations[1], Event = events[1] }, // UK - WHO - Climate Action Forum
                new Participation { Id = 5, Country = countries[3], Organization = organizations[3], Event = events[2] }, // USA - FCDO - Peace and Security Conference
                new Participation { Id = 6, Country = countries[1], Organization = organizations[0], Event = events[2] }  // France - UNICEF - Peace and Security Conference
            };
        }
    }
}
