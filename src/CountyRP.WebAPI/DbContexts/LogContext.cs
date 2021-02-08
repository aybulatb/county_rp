using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.DbContexts
{
    public class LogContext : DbContext
    {
        public DbSet<LogUnit> LogUnits { get; set; }

        public LogContext(DbContextOptions<LogContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
