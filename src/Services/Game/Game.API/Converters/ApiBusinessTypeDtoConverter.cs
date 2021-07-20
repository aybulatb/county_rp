using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiBusinessTypeDtoConverter
    {
        public static BusinessTypeDto ToRepository(
            ApiBusinessTypeDto source
        )
        {
            return source switch
            {
                _ => BusinessTypeDto.Unknown
            };
        }
    }
}
