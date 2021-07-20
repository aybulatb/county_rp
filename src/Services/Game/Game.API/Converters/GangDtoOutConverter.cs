using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class GangDtoOutConverter
    {
        public static ApiGangDtoOut ToApi(
            GangDtoOut source
        )
        {
            return new ApiGangDtoOut(
                id: source.Id,
                name: source.Name,
                color: source.Color,
                ranks: source.Ranks,
                type: GangTypeDtoConverter.ToApi(source.Type),
                createdDate: source.CreatedDate
            );
        }
    }
}
