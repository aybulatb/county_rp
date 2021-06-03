using CountyRP.Services.Logs.DbContexts;
using System;

namespace CountyRP.Services.Logs.Repositories
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
