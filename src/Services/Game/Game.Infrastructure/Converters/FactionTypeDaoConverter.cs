using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class FactionTypeDaoConverter
    {
        public static FactionTypeDto ToRepository(
            FactionTypeDao source
        )
        {
            return source switch
            {
                _ => FactionTypeDto.Unknown
            };
        }
    }
}
