using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class BusinessTypeDtoConverter
    {
        public static BusinessTypeDao ToDb(
            BusinessTypeDto source
        )
        {
            return source switch
            {
                _ => BusinessTypeDao.Unknown
            };
        }
    }
}
