using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class LockerRoomDtoOutConverter
    {
        public static ApiLockerRoomDtoOut ToApi(
            LockerRoomDtoOut source
        )
        {
            return new ApiLockerRoomDtoOut(
                id: source.Id,
                position: source.Position,
                dimension: source.Dimension,
                typeMarker: source.TypeMarker,
                colorMarker: source.ColorMarker,
                factionId: source.FactionId
            );
        }
    }
}
