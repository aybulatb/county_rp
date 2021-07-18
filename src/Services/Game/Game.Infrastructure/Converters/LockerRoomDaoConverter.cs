using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class LockerRoomDaoConverter
    {
        public static LockerRoomDtoOut ToRepository(
            LockerRoomDao source
        )
        {
            return new LockerRoomDtoOut(
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
