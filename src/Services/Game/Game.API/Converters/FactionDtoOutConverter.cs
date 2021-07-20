using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class FactionDtoOutConverter
    {
        public static ApiFactionDtoOut ToApi(
            FactionDtoOut source
        )
        {
            return new ApiFactionDtoOut(
                id: source.Id,
                name: source.Name,
                color: source.Color,
                ranks: source.Ranks,
                type: FactionTypeDtoConverter.ToApi(source.Type)
            );
        }
    }
}
