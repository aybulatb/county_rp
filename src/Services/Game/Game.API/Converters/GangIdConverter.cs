using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class GangIdConverter
    {
        public static GangFilterDtoIn ToGangFilterDtoIn(
            int source
        )
        {
            return new GangFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                name: null,
                nameLike: null,
                types: null
            );
        }
    }
}
