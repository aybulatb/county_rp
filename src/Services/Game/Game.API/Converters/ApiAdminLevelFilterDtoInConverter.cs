using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiAdminLevelFilterDtoInConverter
    {
        public static AdminLevelFilterDtoIn ToRepository(
            ApiAdminLevelFilterDtoIn source
        )
        {
            return new AdminLevelFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                names: source.Names,
                nameLike: source.NameLike
            );
        }
    }
}
