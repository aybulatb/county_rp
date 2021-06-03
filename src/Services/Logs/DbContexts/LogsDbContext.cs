using CountyRP.Services.Logs.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountyRP.Services.Logs.DbContexts
{
    public class LogsDbContext : DbContext
    {
        public DbSet<LogUnitDao> LogUnits { get; set; }

        public LogsDbContext(
            DbContextOptions<LogsDbContext> options
        )
            : base(options)
        {
        }
    }
}
