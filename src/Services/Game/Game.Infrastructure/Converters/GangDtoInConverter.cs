using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class GangDtoInConverter
    {
        public static GangDao ToDb(
            GangDtoIn source
        )
        {
            return new GangDao(
                id: 0,
                name: source.Name,
                color: source.Color,
                ranks: source.Ranks,
                type: GangTypeDtoConverter.ToDb(source.Type),
                createdDate: source.CreatedDate
            );
        }
    }
}
