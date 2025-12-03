namespace EventParticipation.Api.DTOs
{
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
}
