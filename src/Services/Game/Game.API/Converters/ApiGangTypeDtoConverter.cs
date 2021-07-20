using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiGangTypeDtoConverter
    {
        public static GangTypeDto ToRepository(
            ApiGangTypeDto source
        )
        {
            return source switch
            {
                _ => GangTypeDto.Unknown
            };
        }
    }
}
