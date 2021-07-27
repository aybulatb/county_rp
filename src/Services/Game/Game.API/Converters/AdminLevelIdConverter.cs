using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class AdminLevelIdConverter
    {
        public static AdminLevelFilterDtoIn ToAdminLevelFilterDtoIn(
            string source
        )
        {
            return new AdminLevelFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                names: null,
                nameLike: null
            );
        }
    }
}
