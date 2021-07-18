using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class TeleportDaoConverter
    {
        public static TeleportDtoOut ToRepository(
            TeleportDao source
        )
        {
            return new TeleportDtoOut(
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
                factionId: source.FactionId,
                gangId: source.GangId,
                roomId: source.RoomId,
                businessId: source.BusinessId,
                lockDoors: source.LockDoors
            );
        }
    }
}
