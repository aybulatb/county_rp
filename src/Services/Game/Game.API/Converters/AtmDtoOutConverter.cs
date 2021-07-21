using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class AtmDtoOutConverter
    {
        public static ApiAtmDtoOut ToApi(
            AtmDtoOut source
        )
        {
            return new ApiAtmDtoOut(
                id: source.Id,
                position: source.Position,
                dimension: source.Dimension,
                businessId: source.BusinessId
            );
        }
    }
}
