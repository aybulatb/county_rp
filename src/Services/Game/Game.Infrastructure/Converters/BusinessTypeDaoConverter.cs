using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class BusinessTypeDaoConverter
    {
        public static BusinessTypeDto ToRepository(
            BusinessTypeDao source
        )
        {
            return source switch
            {
                _ => BusinessTypeDto.Unknown
            };
        }
    }
}
