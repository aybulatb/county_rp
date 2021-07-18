using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class LockerRoomDtoOutConverter
    {
        public static LockerRoomDao ToDb(
            LockerRoomDtoOut source
        )
        {
            return new LockerRoomDao(
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
