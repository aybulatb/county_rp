using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class GangTypeDtoConverter
    {
        public static ApiGangTypeDto ToApi(
            GangTypeDto source
        )
        {
            return source switch
            {
                _ => ApiGangTypeDto.Unknown
            };
        }
    }
}
