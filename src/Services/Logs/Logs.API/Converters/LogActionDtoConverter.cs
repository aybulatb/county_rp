using CountyRP.Services.Logs.API.Models.Api;
using CountyRP.Services.Logs.Infrastructure.Models;

namespace CountyRP.Services.Logs.API.Converters
{
    public static class LogActionDtoConverter
    {
        public static ApiLogActionDto ToApi(
            LogActionDto source
        )
        {
            return source switch
            {
                LogActionDto.BanInGame => ApiLogActionDto.BanInGame,
                LogActionDto.BanOnSite => ApiLogActionDto.BanOnSite,

                _ => ApiLogActionDto.Unknown
            };
        }
    }
}
