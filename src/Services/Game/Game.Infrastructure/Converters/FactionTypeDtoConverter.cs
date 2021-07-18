using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class FactionTypeDtoConverter
    {
        public static FactionTypeDao ToDb(
            FactionTypeDto source
        )
        {
            return source switch
            {
                _ => FactionTypeDao.Unknown
            };
        }
    }
}
