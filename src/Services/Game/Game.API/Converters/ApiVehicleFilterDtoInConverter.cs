using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiVehicleFilterDtoInConverter
    {
        public static VehicleFilterDtoIn ToRepository(
            ApiVehicleFilterDtoIn source
        )
        {
            return new VehicleFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                models: source.Models,
                ownerIds: source.OwnerIds,
                factionIds: source.FactionIds,
                licensePlate: source.LicensePlate,
                licensePlateLike: source.LicensePlateLike
            );
        }
    }
}
