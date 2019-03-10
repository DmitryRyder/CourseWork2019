using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DAL
{
    public class PlanetsDatabaseContext : DbContext
    {
        public PlanetsDatabaseContext(DbContextOptions<PlanetsDatabaseContext> options) : base(options) { }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<Sattelite> Satellites { get; set; }
    }
}
