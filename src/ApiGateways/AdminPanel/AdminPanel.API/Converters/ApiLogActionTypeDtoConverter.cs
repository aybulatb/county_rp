using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ApiLogActionTypeDtoConverter
    {
        public static LogsLogActionTypeDto ToService(
            ApiLogActionTypeDto source
        )
        {
            return source switch
            {
                ApiLogActionTypeDto.BanInGame => LogsLogActionTypeDto.BanInGame,
                ApiLogActionTypeDto.BanOnSite => LogsLogActionTypeDto.BanOnSite,

                _ => LogsLogActionTypeDto.Unknown
            };
        }
    }
}
