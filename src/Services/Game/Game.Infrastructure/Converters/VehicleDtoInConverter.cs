using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class VehicleDtoInConverter
    {
        public static VehicleDao ToDb(
            VehicleDtoIn source
        )
        {
            return new VehicleDao(
                id: 0,
                model: source.Model,
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
