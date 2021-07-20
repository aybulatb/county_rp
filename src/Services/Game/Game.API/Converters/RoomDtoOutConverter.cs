using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class RoomDtoOutConverter
    {
        public static ApiRoomDtoOut ToApi(
            RoomDtoOut source
        )
        {
            return new ApiRoomDtoOut(
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
