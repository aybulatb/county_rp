using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiTeleportDtoInConverter
    {
        public static TeleportDtoIn ToRepository(
            ApiTeleportDtoIn source
        )
        {
            return new TeleportDtoIn(
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
