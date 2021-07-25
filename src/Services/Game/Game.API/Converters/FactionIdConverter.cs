using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class FactionIdConverter
    {
        public static FactionFilterDtoIn ToFactionFilterDtoIn(
            string source
        )
        {
            return new FactionFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                idLike: null,
                names: null,
                nameLike: null,
                types: null
            );
        }
    }
}
