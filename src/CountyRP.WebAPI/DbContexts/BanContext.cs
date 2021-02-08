using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.DbContexts
{
    public class BanContext : DbContext
    {
        public DbSet<SiteBan> SiteBans { get; set; }
        public DbSet<GameBan> GameBans { get; set; }

        public BanContext(DbContextOptions<BanContext> options) 
            : base(options)
        {
            Database.Migrate();
        }
    }
}
