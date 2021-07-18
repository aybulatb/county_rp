using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class HouseDaoConverter
    {
        public static HouseDtoOut ToRepository(
            HouseDao source
        )
        {
            return new HouseDtoOut(
                id: source.Id,
                entrancePosition: source.EntrancePosition,
                entranceDimension: source.EntranceDimension,
                exitPosition: source.ExitPosition,
                exitDimension: source.ExitDimension,
                ownerId: source.OwnerId,
                garageId: source.GarageId,
                lockDoors: source.LockDoors,
                price: source.Price,
                safePosition: source.SafePosition,
                safeDimension: source.SafeDimension,
                safeInventoryId: source.SafeInventoryId
            );
        }
    }
}
