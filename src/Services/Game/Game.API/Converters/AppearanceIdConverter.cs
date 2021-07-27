using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class AppearanceIdConverter
    {
        public static AppearanceFilterDtoIn ToAppearanceFilterDtoIn(
            int source
        )
        {
            return new AppearanceFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source }
            );
        }
    }
}
