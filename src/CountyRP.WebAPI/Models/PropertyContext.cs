using Microsoft.EntityFrameworkCore;

using CountyRP.Entities;

namespace CountyRP.WebAPI.Models
{
    public class PropertyContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Teleport> Teleports { get; set; }

        public PropertyContext(DbContextOptions<PropertyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
