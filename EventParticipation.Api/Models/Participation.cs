namespace EventParticipation.Api.Models
{
    public class Participation
    {
        public int Id { get; set; }
        public Country Country { get; set; } = null!;
        public Organization Organization { get; set; } = null!;
        public Event Event { get; set; } = null!;
    }
}