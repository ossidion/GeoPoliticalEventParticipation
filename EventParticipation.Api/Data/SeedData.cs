using EventParticipation.Api.Models;

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
                new Country { Id = 4, Name = "United States", Region = "North America", GDP = 21000, Population = 331 },
                new Country { Id = 5, Name = "Canada", Region = "North America", GDP = 1800, Population = 38 },
                new Country { Id = 6, Name = "Australia", Region = "Oceania", GDP = 1400, Population = 25 },
                new Country { Id = 7, Name = "Japan", Region = "Asia", GDP = 5000, Population = 126 },
                new Country { Id = 8, Name = "India", Region = "Asia", GDP = 2900, Population = 1380 },
                new Country { Id = 9, Name = "China", Region = "Asia", GDP = 14700, Population = 1440 },
                new Country { Id = 10, Name = "Brazil", Region = "South America", GDP = 2200, Population = 213 },
                new Country { Id = 11, Name = "South Africa", Region = "Africa", GDP = 350, Population = 60 },
                new Country { Id = 12, Name = "Nigeria", Region = "Africa", GDP = 450, Population = 206 },
                new Country { Id = 13, Name = "Kenya", Region = "Africa", GDP = 110, Population = 54 },
                new Country { Id = 14, Name = "Mexico", Region = "North America", GDP = 1300, Population = 129 },
                new Country { Id = 15, Name = "Spain", Region = "Europe", GDP = 1400, Population = 47 },
                new Country { Id = 16, Name = "Italy", Region = "Europe", GDP = 2100, Population = 60 },
                new Country { Id = 17, Name = "Norway", Region = "Europe", GDP = 450, Population = 5 },
                new Country { Id = 18, Name = "Sweden", Region = "Europe", GDP = 630, Population = 10 },
                new Country { Id = 19, Name = "Turkey", Region = "Asia", GDP = 820, Population = 84 },
                new Country { Id = 20, Name = "South Korea", Region = "Asia", GDP = 1700, Population = 52 }
            };
        }

        public static List<Organisation> GetOrganisations()
        {
            return new List<Organisation>
            {
                new Organisation { Id = 1, Name = "UNICEF", OrgType = "UN Agency" },
                new Organisation { Id = 2, Name = "WHO", OrgType = "UN Agency" },
                new Organisation { Id = 3, Name = "Red Cross", OrgType = "NGO" },
                new Organisation { Id = 4, Name = "FCDO", OrgType = "Government Department" },
                new Organisation { Id = 5, Name = "Amnesty International", OrgType = "NGO" },
                new Organisation { Id = 6, Name = "UNDP", OrgType = "UN Agency" },
                new Organisation { Id = 7, Name = "World Bank", OrgType = "IGO" },
                new Organisation { Id = 8, Name = "NATO", OrgType = "IGO" },
                new Organisation { Id = 9, Name = "Oxfam", OrgType = "NGO" },
                new Organisation { Id = 10, Name = "Médecins Sans Frontières", OrgType = "NGO" }
            };
        }

        public static List<Event> GetEvents(int count = 30)
        {
            var rnd = new Random(42);

            var eventNames = new[]
            {
                "Global Health Security Conference",
                "Climate Resilience Summit",
                "Humanitarian Coordination Forum",
                "Cybersecurity and Digital Governance Expo",
                "International Peace and Stability Dialogue",
                "Refugee and Migration Roundtable",
                "Sustainable Development Partnership Forum",
                "Arctic Security Cooperation Meeting",
                "Indo-Pacific Strategic Dialogue",
                "Global Water Security Symposium",
                "Energy Transition Summit",
                "African Economic Partnership Forum",
                "Economic Recovery and Reconstruction Conference",
                "Food Security and Agriculture Innovation Forum",
                "Women, Peace & Security Congress",
                "Anti-Corruption and Transparency Forum",
                "Disaster Response Coordination Workshop",
                "Counter-Terrorism Cooperation Meeting",
                "International Education and Development Forum",
                "Global Trade and Investment Summit",
                "Maritime Security and Anti-Piracy Conference",
                "Human Rights Dialogue",
                "Multilateral Aid Effectiveness Roundtable",
                "International Health Workforce Congress",
                "Digital Transformation and AI Ethics Forum",
                "Urban Resilience and Infrastructure Summit"
            };

            string[] categories = { "Security", "Climate", "Health", "Trade", "Humanitarian", "Development", "Digital" };

            var selected = eventNames.OrderBy(_ => rnd.Next()).Take(count).ToList();
            var list = new List<Event>();

            for (int i = 0; i < selected.Count; i++)
            {
                list.Add(new Event
                {
                    Id = i + 1,
                    Name = selected[i],
                    Date = DateTime.UtcNow.AddDays(-rnd.Next(50, 1500)),
                    Category = categories[rnd.Next(categories.Length)]
                });
            }
            return list;
        }

        public static List<Participation> GenerateParticipations(
            List<Country> countries,
            List<Organisation> organizations,
            List<Event> events)
        {
            var rnd = new Random(42);
            var participations = new List<Participation>();
            int idCounter = 1;

            foreach (var ev in events)
            {
                int count = rnd.Next(5, 20); // 5–20 participations per event

                for (int i = 0; i < count; i++)
                {
                    participations.Add(new Participation
                    {
                        Id = idCounter++,
                        Country = countries[rnd.Next(countries.Count)],
                        Organisation = organizations[rnd.Next(organizations.Count)],
                        Event = ev
                    });
                }
            }
            return participations;
        }
    }
}
