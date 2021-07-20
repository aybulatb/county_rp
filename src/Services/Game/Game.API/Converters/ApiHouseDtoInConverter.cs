using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiHouseDtoInConverter
    {
        public static HouseDtoIn ToRepository(
            ApiHouseDtoIn source
        )
        {
            return new HouseDtoIn(
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
