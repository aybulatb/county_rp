using CountyRP.Services.Logs.Infrastructure.DbContexts;
using System;

namespace CountyRP.Services.Logs.Infrastructure.Repositories
{
    public partial class LogsRepository : ILogsRepository
    {
        private LogsDbContext _logsDbContext;

        public LogsRepository(
            LogsDbContext logsDbContext
        )
        {
            _logsDbContext = logsDbContext ?? throw new ArgumentNullException(nameof(logsDbContext));
        }
    }
}
