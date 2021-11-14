using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class LogsLogActionTypeDtoConverter
    {
        public static ApiLogActionTypeDto ToApi(
            LogsLogActionTypeDto source
        )
        {
            return source switch
            {
                LogsLogActionTypeDto.BanInGame => ApiLogActionTypeDto.BanInGame,
                LogsLogActionTypeDto.BanOnSite => ApiLogActionTypeDto.BanOnSite,

                _ => ApiLogActionTypeDto.Unknown
            };
        }
    }
}
