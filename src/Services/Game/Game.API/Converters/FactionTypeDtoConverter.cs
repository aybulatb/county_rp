using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class FactionTypeDtoConverter
    {
        public static ApiFactionTypeDto ToApi(
            FactionTypeDto source
        )
        {
            return source switch
            {
                _ => ApiFactionTypeDto.Unknown
            };
        }
    }
}
