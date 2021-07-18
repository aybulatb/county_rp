using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class GangDaoConverter
    {
        public static GangDtoOut ToRepository(
            GangDao source
        )
        {
            return new GangDtoOut(
                id: source.Id,
                name: source.Name,
                color: source.Color,
                ranks: source.Ranks,
                type: GangTypeDaoConverter.ToRepository(source.Type),
                createdDate: source.CreatedDate
            );
        }
    }
}
