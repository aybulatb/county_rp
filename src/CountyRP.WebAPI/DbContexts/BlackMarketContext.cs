using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.DbContexts
{
    public class BlackMarketContext : DbContext
    {
        public DbSet<BlackMarketItem> BlackMarket { get; set; }

        public BlackMarketContext(DbContextOptions<BlackMarketContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
