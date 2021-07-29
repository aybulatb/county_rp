using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using System.Linq;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiGangFilterDtoInConverter
    {
        public static GangFilterDtoIn ToRepository(
            ApiGangFilterDtoIn source
        )
        {
            return new GangFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                name: source.Name,
                nameLike: source.NameLike,
                types: source.Types
                    ?.Select(ApiGangTypeDtoConverter.ToRepository)
            );
        }
    }
}
