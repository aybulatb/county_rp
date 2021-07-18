using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class LockerRoomDtoInConverter
    {
        public static LockerRoomDao ToDb(
            LockerRoomDtoIn source
        )
        {
            return new LockerRoomDao(
                id: 0,
                position: source.Position,
                dimension: source.Dimension,
                typeMarker: source.TypeMarker,
                colorMarker: source.ColorMarker,
                factionId: source.FactionId
            );
        }
    }
}
