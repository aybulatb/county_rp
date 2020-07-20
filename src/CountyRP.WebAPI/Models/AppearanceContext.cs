using Microsoft.EntityFrameworkCore;

using CountyRP.Entities;

namespace CountyRP.WebAPI.Models
{
    public class AppearanceContext : DbContext
    {
        public DbSet<Appearance> Appearances { get; set; }

        public AppearanceContext(DbContextOptions<AppearanceContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
