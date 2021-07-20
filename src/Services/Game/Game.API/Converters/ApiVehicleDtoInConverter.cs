using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiVehicleDtoInConverter
    {
        public static VehicleDtoIn ToRepository(
            ApiVehicleDtoIn source
        )
        {
            return new VehicleDtoIn(
                model: source.Model,
                position: source.Position,
                rotation: source.Rotation,
                dimension: source.Dimension,
                color1: source.Color1,
                color2: source.Color2,
                fuel: source.Fuel,
                ownerId: source.OwnerId,
                factionId: source.FactionId,
                lockDoors: source.LockDoors,
                licensePlate: source.LicensePlate
            );
        }

        public static VehicleDtoOut ToDtoOut(
            ApiVehicleDtoIn source,
            int id
        )
        {
            return new VehicleDtoOut(
                id: id,
                model: source.Model,
                position: source.Position,
                rotation: source.Rotation,
                dimension: source.Dimension,
                color1: source.Color1,
                color2: source.Color2,
                fuel: source.Fuel,
                ownerId: source.OwnerId,
                factionId: source.FactionId,
                lockDoors: source.LockDoors,
                licensePlate: source.LicensePlate
            );
        }
    }
}
