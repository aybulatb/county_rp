using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceLogs;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Converters
{
    internal static class LogsLogActionTypeDtoConverter
    {
        public static ApiLogActionDto ToExternalApi(
            LogsLogActionTypeDto source
        )
        {
            return source switch
            {
                LogsLogActionTypeDto.BanInGame => ApiLogActionDto.BanInGame,
                LogsLogActionTypeDto.BanOnSite => ApiLogActionDto.BanOnSite,

                _ => ApiLogActionDto.Unknown
            };
        }
    }
}
