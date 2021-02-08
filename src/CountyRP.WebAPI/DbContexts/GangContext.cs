using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.DbContexts
{
    public class GangContext : DbContext
    {
        public DbSet<Gang> Gangs { get; set; }

        public GangContext(DbContextOptions<GangContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
