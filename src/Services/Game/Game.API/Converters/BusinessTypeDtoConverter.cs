using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class BusinessTypeDtoConverter
    {
        public static ApiBusinessTypeDto ToApi(
            BusinessTypeDto source
        )
        {
            return source switch
            {
                _ => ApiBusinessTypeDto.Unknown
            };
        }
    }
}
