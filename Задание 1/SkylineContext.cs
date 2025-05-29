using LAB3.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB3
{
    public class SkylineContext : DbContext
    {
        public DbSet<Star> Stars { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Constellation> Constellations { get; set; }
        public SkylineContext(DbContextOptions options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=app.db");
            }
        }
    }
}