using CountyRP.Services.Logs.Entities;
using CountyRP.Services.Logs.Models;
using CountyRP.Services.Logs.Models.Api;

namespace CountyRP.Services.Logs.Converters
{
    public static class LogActionDtoConverter
    {
        public static LogActionDao ToDb(
            LogActionDto source
        )
        {
            return source switch
            {
                LogActionDto.BanInGame => LogActionDao.BanInGame,
                LogActionDto.BanOnSite => LogActionDao.BanOnSite,

                _ => LogActionDao.Unknown
            };
        }

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
