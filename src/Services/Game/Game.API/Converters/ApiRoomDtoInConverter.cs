using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiRoomDtoInConverter
    {
        public static RoomDtoIn ToRepository(
            ApiRoomDtoIn source
        )
        {
            return new RoomDtoIn(
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

        public static RoomDtoOut ToDtoOutRepository(
            ApiRoomDtoIn source,
            int id
        )
        {
            return new RoomDtoOut(
                id: id,
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
