using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiGangDtoInConverter
    {
        public static GangDtoIn ToRepository(
            ApiGangDtoIn source
        )
        {
            return new GangDtoIn(
                name: source.Name,
                color: source.Color,
                ranks: source.Ranks,
                type: ApiGangTypeDtoConverter.ToRepository(source.Type),
                createdDate: source.CreatedDate
            );
        }
    }
}
