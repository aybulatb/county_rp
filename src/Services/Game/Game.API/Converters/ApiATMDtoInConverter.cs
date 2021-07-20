using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiATMDtoInConverter
    {
        public static ATMDtoIn ToRepository(
            ApiATMDtoIn source
        )
        {
            return new ATMDtoIn(
                position: source.Position,
                dimension: source.Dimension,
                businessId: source.BusinessId
            );
        }
    }
}
