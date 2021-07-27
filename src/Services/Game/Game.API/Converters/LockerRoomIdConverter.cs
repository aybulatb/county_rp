using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class LockerRoomIdConverter
    {
        public static LockerRoomFilterDtoIn ToLockerRoomFilterDtoIn(
            int source
        )
        {
            return new LockerRoomFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                factionIds: null
            );
        }
    }
}
