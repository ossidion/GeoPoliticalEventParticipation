using Microsoft.EntityFrameworkCore;
using EventParticipation.Api.Models;

namespace EventParticipation.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Organisation> Organizations { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<Participation> Participations { get; set; }
    }
}