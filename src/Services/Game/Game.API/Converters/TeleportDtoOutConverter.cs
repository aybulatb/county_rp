using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public class TeleportDtoOutConverter
    {
        public static ApiTeleportDtoOut ToApi(
            TeleportDtoOut source
        )
        {
            return new ApiTeleportDtoOut(
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
