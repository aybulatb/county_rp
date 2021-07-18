using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class GarageDaoConverter
    {
        public static GarageDtoOut ToRepository(
            GarageDao source
        )
        {
            return new GarageDtoOut(
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
