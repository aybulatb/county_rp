using CountyRP.Services.Logs.Infrastructure.Entities;
using CountyRP.Services.Logs.Infrastructure.Models;

namespace CountyRP.Services.Logs.Infrastructure.Converters
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
    }
}
