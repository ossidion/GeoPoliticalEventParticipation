namespace EventParticipation.Api.Models
{
    public class Participation
    {
        public Country Country { get; set; } = null!;
        public Organization Organization { get; set; } = null!;
        public Event EventArgs { get; set; } = null!;
    }
}