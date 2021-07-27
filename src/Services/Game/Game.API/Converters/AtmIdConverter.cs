using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class AtmIdConverter
    {
        public static AtmFilterDtoIn ToAtmFilterDtoIn(
            int source
        )
        {
            return new AtmFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                businessIds: null
            );
        }
    }
}
