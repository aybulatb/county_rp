using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceLogs;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Converters
{
    internal static class ApiLogActionDtoConverter
    {
        public static LogsLogActionTypeDto ToService(
            ApiLogActionDto source
        )
        {
            return source switch
            {
                ApiLogActionDto.BanInGame => LogsLogActionTypeDto.BanInGame,
                ApiLogActionDto.BanOnSite => LogsLogActionTypeDto.BanOnSite,

                _ => LogsLogActionTypeDto.Unknown
            };
        }
    }
}
