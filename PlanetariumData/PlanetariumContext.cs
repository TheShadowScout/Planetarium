using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetariumData
{
    public class PlanetariumContext : DbContext
    {
        public PlanetariumContext(DbContextOptions options) : base(options){ }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<StarSystem> StarSystems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>().HasKey(planet => new { planet.Id, planet.StarSystemId });
        }
    }
}
