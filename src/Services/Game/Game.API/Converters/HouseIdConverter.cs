using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class HouseIdConverter
    {
        public static HouseFilterDtoIn ToHouseFilterDtoIn(
            int source
        )
        {
            return new HouseFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                ownerIds: null,
                garageIds: null
            );
        }
    }
}
