using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using System.Linq;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiFactionFilterDtoInConverter
    {
        public static FactionFilterDtoIn ToRepository(
            ApiFactionFilterDtoIn source
        )
        {
            return new FactionFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                idLike: source.IdLike,
                names: source.Names,
                nameLike: source.NameLike,
                types: source.Types
                    ?.Select(ApiFactionTypeDtoConverter.ToRepository)
            );
        }
    }
}
