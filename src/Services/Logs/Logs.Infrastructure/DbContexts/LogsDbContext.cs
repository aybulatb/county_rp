using CountyRP.Services.Logs.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountyRP.Services.Logs.Infrastructure.DbContexts
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
