using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Contexts
{
    public class PlanetsDatabaseContext : DbContext
    {
        public PlanetsDatabaseContext(DbContextOptions<PlanetsDatabaseContext> options) : base(options) { }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<Sattelite> Satellites { get; set; }
    }
}
