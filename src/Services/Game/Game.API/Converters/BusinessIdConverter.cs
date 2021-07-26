using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class BusinessIdConverter
    {
        public static BusinessFilterDtoIn ToBusinessFilterDtoIn(
            int source
        )
        {
            return new BusinessFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                name: null,
                nameLike: null,
                ownerIds: null,
                types: null
            );
        }
    }
}
