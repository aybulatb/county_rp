using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiAppearanceFilterDtoInConverter
    {
        public static AppearanceFilterDtoIn ToRepository(
            ApiAppearanceFilterDtoIn source
        )
        {
            return new AppearanceFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids
            );
        }
    }
}
