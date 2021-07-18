using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class GarageDtoOutConverter
    {
        public static GarageDao ToDb(
            GarageDtoOut source
        )
        {
            return new GarageDao(
                id: source.Id,
                type: source.Type,
                entrancePosition: source.EntrancePosition,
                entranceDimension: source.EntranceDimension,
                entranceRotation: source.EntranceRotation,
                exitDimension: source.ExitDimension,
                lockDoors: source.LockDoors
            );
        }
    }
}
