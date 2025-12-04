using EventParticipation.Api.Models;
using System;
using System.Collections.Generic;

namespace EventParticipation.Api.Data
{
    public static class SeedData
    {
        public static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country { Id = 1, Name = "United Kingdom", Region = "Europe", GDP = 3100, Population = 68 },
                new Country { Id = 2, Name = "France", Region = "Europe", GDP = 2800, Population = 65 },
                new Country { Id = 3, Name = "Germany", Region = "Europe", GDP = 4200, Population = 83 },
                new Country { Id = 4, Name = "Spain", Region = "Europe", GDP = 2000, Population = 47 },
                new Country { Id = 5, Name = "Italy", Region = "Europe", GDP = 2200, Population = 60 }
            };
        }

        public static List<Organisation> GetOrganisations()
        {
            return new List<Organisation>
            {
                new Organisation { Id = 1, Name = "UNICEF", OrgType = "UN Agency" },
                new Organisation { Id = 2, Name = "WHO", OrgType = "UN Agency" },
                new Organisation { Id = 3, Name = "Red Cross", OrgType = "NGO" },
                new Organisation { Id = 4, Name = "FCDO", OrgType = "Government" },
                new Organisation { Id = 5, Name = "Doctors Without Borders", OrgType = "NGO" }
            };
        }

        public static List<Event> GetEvents()
        {
            var events = new List<Event>();
            int id = 1;

            events.Add(new Event { Id = id++, Name = "Global Health Summit", Date = new DateTime(2023, 1, 15), Category = "Health" });
            events.Add(new Event { Id = id++, Name = "Climate Action Forum", Date = new DateTime(2023, 3, 10), Category = "Climate" });
            events.Add(new Event { Id = id++, Name = "Peace Conference", Date = new DateTime(2023, 5, 5), Category = "Security" });
            events.Add(new Event { Id = id++, Name = "Tech Forum", Date = new DateTime(2024, 6, 12), Category = "Tech" });
            events.Add(new Event { Id = id++, Name = "Education Summit", Date = new DateTime(2024, 8, 20), Category = "Education" });
            events.Add(new Event { Id = id++, Name = "Climate Action Forum 2", Date = new DateTime(2024, 10, 5), Category = "Climate" });
            events.Add(new Event { Id = id++, Name = "Health Workshop", Date = new DateTime(2024, 11, 15), Category = "Health" });
            events.Add(new Event { Id = id++, Name = "Security Forum", Date = new DateTime(2023, 7, 20), Category = "Security" });
            events.Add(new Event { Id = id++, Name = "Innovation Summit", Date = new DateTime(2024, 4, 10), Category = "Tech" });
            events.Add(new Event { Id = id++, Name = "Global Education Forum", Date = new DateTime(2023, 9, 5), Category = "Education" });
            events.Add(new Event { Id = id++, Name = "Healthcare Innovation", Date = new DateTime(2024, 2, 18), Category = "Health" });
            events.Add(new Event { Id = id++, Name = "Sustainability Conference", Date = new DateTime(2023, 11, 12), Category = "Climate" });
            events.Add(new Event { Id = id++, Name = "Peacebuilding Workshop", Date = new DateTime(2024, 5, 25), Category = "Security" });
            events.Add(new Event { Id = id++, Name = "Tech for Good", Date = new DateTime(2023, 8, 15), Category = "Tech" });
            events.Add(new Event { Id = id++, Name = "Education Innovation", Date = new DateTime(2024, 9, 30), Category = "Education" });

            return events;
        }

        public static List<Participation> GenerateParticipations()
        {
            var countries = GetCountries();
            var organizations = GetOrganisations();
            var events = GetEvents();

            var participations = new List<Participation>();
            int id = 1;

            foreach (var ev in events)
            {
                foreach (var country in countries)
                {
                    foreach (var org in organizations)
                    {
                        // Optimized for trend + collaboration + influence metrics
                        if ((ev.Id + country.Id + org.Id) % 2 == 0 || (ev.Date.Year == 2024 && org.Name == "FCDO"))
                        {
                            participations.Add(new Participation
                            {
                                Id = id++,
                                Country = country,
                                Organisation = org,
                                Event = ev
                            });
                        }
                    }
                }
            }

            return participations;
        }
    }
}
