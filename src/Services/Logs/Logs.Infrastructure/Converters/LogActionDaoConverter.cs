using CountyRP.Services.Logs.Infrastructure.Entities;
using CountyRP.Services.Logs.Infrastructure.Models;

namespace CountyRP.Services.Logs.Infrastructure.Converters
{
    public class LogActionDaoConverter
    {
        public static LogActionDto ToRepository(
            LogActionDao source
        )
        {
            return source switch
            {
                LogActionDao.BanInGame => LogActionDto.BanInGame,
                LogActionDao.BanOnSite => LogActionDto.BanOnSite,

                _ => LogActionDto.Unknown
            };
        }
    }
}
