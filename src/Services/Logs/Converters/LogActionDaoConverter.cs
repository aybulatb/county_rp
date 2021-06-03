using CountyRP.Services.Logs.Entities;
using CountyRP.Services.Logs.Models;

namespace CountyRP.Services.Logs.Converters
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
