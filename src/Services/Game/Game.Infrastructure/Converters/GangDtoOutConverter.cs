using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class GangDtoOutConverter
    {
        public static GangDao ToDb(
            GangDtoOut source
        )
        {
            return new GangDao(
                id: source.Id,
                name: source.Name,
                color: source.Color,
                ranks: source.Ranks,
                type: GangTypeDtoConverter.ToDb(source.Type),
                createdDate: source.CreatedDate
            );
        }
    }
}
