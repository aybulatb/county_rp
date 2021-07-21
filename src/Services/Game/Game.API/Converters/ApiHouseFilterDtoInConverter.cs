using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiHouseFilterDtoInConverter
    {
        public static HouseFilterDtoIn ToRepository(
            ApiHouseFilterDtoIn source
        )
        {
            return new HouseFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                ownerIds: source.OwnerIds,
                garageIds: source.GarageIds
            );
        }
    }
}
