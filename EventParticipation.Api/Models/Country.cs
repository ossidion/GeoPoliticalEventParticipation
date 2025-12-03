namespace EventParticipation.Api.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal GDP { get; set; }
        public int Population { get; set; }
        public string Region { get; set; } = string.Empty;
    }
}