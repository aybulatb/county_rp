using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class GangTypeDtoConverter
    {
        public static GangTypeDao ToDb(
            GangTypeDto source
        )
        {
            return source switch
            {
                _ => GangTypeDao.Unknown
            };
        }
    }
}
