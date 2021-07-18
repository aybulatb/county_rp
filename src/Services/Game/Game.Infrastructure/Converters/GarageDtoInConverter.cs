using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class GarageDtoInConverter
    {
        public static GarageDao ToDb(
            GarageDtoIn source
        )
        {
            return new GarageDao(
                id: 0,
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
