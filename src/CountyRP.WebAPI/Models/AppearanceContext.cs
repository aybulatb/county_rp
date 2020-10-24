using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

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
