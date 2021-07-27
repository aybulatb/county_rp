using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class GarageIdConverter
    {
        public static GarageFilterDtoIn ToGarageFilterDtoIn(
            int source
        )
        {
            return new GarageFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source }
            );
        }
    }
}
