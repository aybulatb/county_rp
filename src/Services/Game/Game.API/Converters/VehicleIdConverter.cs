using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class VehicleIdConverter
    {
        public static VehicleFilterDtoIn ToVehicleFilterDtoIn(
            int source
        )
        {
            return new VehicleFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                models: null,
                ownerIds: null,
                factionIds: null,
                licensePlate: null,
                licensePlateLike: null
            );
        }
    }
}
