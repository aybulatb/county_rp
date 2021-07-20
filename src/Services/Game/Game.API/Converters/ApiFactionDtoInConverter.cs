using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiFactionDtoInConverter
    {
        public static FactionDtoIn ToRepository(
            ApiFactionDtoIn source
        )
        {
            return new FactionDtoIn(
                id: source.Id,
                name: source.Name,
                color: source.Color,
                ranks: source.Ranks,
                type: ApiFactionTypeDtoConverter.ToRepository(source.Type)
            );
        }
    }
}
