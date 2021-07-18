using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class RoomDtoOutConverter
    {
        public static RoomDao ToDb(
            RoomDtoOut source
        )
        {
            return new RoomDao(
                id: source.Id,
                name: source.Name,
                entrancePosition: source.EntrancePosition,
                entranceDimension: source.EntranceDimension,
                exitPosition: source.ExitPosition,
                exitDimension: source.ExitDimension,
                typeMarker: source.TypeMarker,
                colorMarker: source.ColorMarker,
                typeBlip: source.TypeBlip,
                colorBlip: source.ColorBlip,
                gangId: source.GangId,
                lockDoors: source.LockDoors,
                price: source.Price,
                lastPaymentDate: source.LastPaymentDate,
                safePosition: source.SafePosition,
                safeDimension: source.SafeDimension
            );
        }
    }
}
