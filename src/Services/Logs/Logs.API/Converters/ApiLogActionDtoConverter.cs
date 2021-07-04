using CountyRP.Services.Logs.API.Models.Api;
using CountyRP.Services.Logs.Infrastructure.Models;

namespace CountyRP.Services.Logs.API.Converters
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
