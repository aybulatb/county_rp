using CountyRP.Services.Logs.Models;
using CountyRP.Services.Logs.Models.Api;

namespace CountyRP.Services.Logs.Converters
{
    public static class ApiLogActionDtoConverter
    {
        public static LogActionDto ToRepository(
            ApiLogActionDto source
        )
        {
            return source switch
            {
                ApiLogActionDto.BanInGame => LogActionDto.BanInGame,
                ApiLogActionDto.BanOnSite => LogActionDto.BanOnSite,

                _ => LogActionDto.Unknown
            };
        }
    }
}
