using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiFactionTypeDtoConverter
    {
        public static FactionTypeDto ToRepository(
            ApiFactionTypeDto source
        )
        {
            return source switch
            {
                _ => FactionTypeDto.Unknown
            };
        }
    }
}
