using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceLogs;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Converters
{
    internal static class ApiPagedFilterResultDtoOutConverter
    {
        public static LogsPagedFilterResultDtoOut<LogsLogUnitDtoOut> ToService(
            ApiPagedFilterResultDtoOutOfApiLogUnitDtoOut source
        )
        {
            return new LogsPagedFilterResultDtoOut<LogsLogUnitDtoOut>(
                AllCount: source.AllCount,
                Page: source.Page,
                MaxPages: source.MaxPages,
                Items: source.Items
                    .Select(ApiLogUnitDtoOutConverter.ToService)
            );
        }
    }
}
