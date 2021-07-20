using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class VehicleDaoConverter
    {
        public static VehicleDtoOut ToRepository(
            VehicleDao source
        )
        {
            return new VehicleDtoOut(
                id: source.Id,
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
