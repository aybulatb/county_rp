using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.Models
{
    public class PropertyContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Teleport> Teleports { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ATM> ATMs { get; set; }

        public PropertyContext(DbContextOptions<PropertyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
