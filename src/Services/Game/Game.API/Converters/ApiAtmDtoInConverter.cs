using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiAtmDtoInConverter
    {
        public static AtmDtoIn ToRepository(
            ApiAtmDtoIn source
        )
        {
            return new AtmDtoIn(
                position: source.Position,
                dimension: source.Dimension,
                businessId: source.BusinessId
            );
        }

        public static AtmDtoOut ToDtoOutRepository(
            ApiAtmDtoIn source,
            int id
        )
        {
            return new AtmDtoOut(
                id: id,
                position: source.Position,
                dimension: source.Dimension,
                businessId: source.BusinessId
            );
        }
    }
}
