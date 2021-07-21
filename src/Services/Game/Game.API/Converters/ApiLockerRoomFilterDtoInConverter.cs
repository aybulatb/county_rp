using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiLockerRoomFilterDtoInConverter
    {
        public static LockerRoomFilterDtoIn ToRepository(
            ApiLockerRoomFilterDtoIn source
        )
        {
            return new LockerRoomFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                factionIds: source.FactionIds
            );
        }
    }
}
