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

    public class CountryCollaborationDto
    {
        public string Country { get; set; } = string.Empty;
        public double Score { get; set; }
    }

    public class OrganisationInflucenceDto
    {
        public string Organisation
        {
            get; set;
        } = string.Empty;

        public double Score { get; set; }
    }

    public class CountryTrendDto
    {
        public string Country { get; set; } = string.Empty;
        public int CurrentPeriodCount { get; set; }
        public int PreviousPeriodCount { get; set; }
        public double TrendScore { get; set; }
    }
}
