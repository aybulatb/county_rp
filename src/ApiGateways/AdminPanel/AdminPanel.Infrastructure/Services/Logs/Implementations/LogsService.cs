using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceLogs;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Interfaces;
using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Implementations
{
    public partial class LogsService : ILogsService
    {
        private readonly ILogUnitClient _logUnitClient;

        public LogsService(
            ILogUnitClient logUnitClient
        )
        {
            _logUnitClient = logUnitClient ?? throw new ArgumentNullException(nameof(logUnitClient));
        }
    }
}
