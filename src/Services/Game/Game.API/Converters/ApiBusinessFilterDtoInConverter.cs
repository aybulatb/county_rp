using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using System.Linq;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiBusinessFilterDtoInConverter
    {
        public static BusinessFilterDtoIn ToRepository(
            ApiBusinessFilterDtoIn source
        )
        {
            return new BusinessFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                name: source.Name,
                nameLike: source.NameLike,
                ownerIds: source.OwnerIds,
                types: source.Types
                    .Select(ApiBusinessTypeDtoConverter.ToRepository)
            );
        }
    }
}
