using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiLockerRoomDtoInConverter
    {
        public static LockerRoomDtoIn ToRepository(
            ApiLockerRoomDtoIn source
        )
        {
            return new LockerRoomDtoIn(
                position: source.Position,
                dimension: source.Dimension,
                typeMarker: source.TypeMarker,
                colorMarker: source.ColorMarker,
                factionId: source.FactionId
            );
        }

        public static LockerRoomDtoOut ToDtoOutRepository(
            ApiLockerRoomDtoIn source,
            int id
        )
        {
            return new LockerRoomDtoOut(
                id: id,
                position: source.Position,
                dimension: source.Dimension,
                typeMarker: source.TypeMarker,
                colorMarker: source.ColorMarker,
                factionId: source.FactionId
            );
        }
    }
}
