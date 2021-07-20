using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiEditedGangDtoInConverter
    {
        public static EditedGangDtoIn ToRepository(
            ApiEditedGangDtoIn source,
            int id
        )
        {
            return new EditedGangDtoIn(
                id: id,
                name: source.Name,
                color: source.Color,
                ranks: source.Ranks,
                type: ApiGangTypeDtoConverter.ToRepository(source.Type)
            );
        }
    }
}
