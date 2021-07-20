using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ATMDtoOutConverter
    {
        public static ApiATMDtoOut ToApi(
            ATMDtoOut source
        )
        {
            return new ApiATMDtoOut(
                id: source.Id,
                position: source.Position,
                dimension: source.Dimension,
                businessId: source.BusinessId
            );
        }
    }
}
