using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class GangTypeDaoConverter
    {
        public static GangTypeDto ToRepository(
            GangTypeDao source
        )
        {
            return source switch
            {
                _ => GangTypeDto.Unknown
            };
        }
    }
}
