using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.DbContexts
{
    public class AdminLevelContext : DbContext
    {
        public DbSet<AdminLevel> AdminLevels { get; set; }

        public AdminLevelContext(DbContextOptions<AdminLevelContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
