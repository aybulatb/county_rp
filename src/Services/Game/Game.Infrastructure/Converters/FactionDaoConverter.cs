using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class FactionDaoConverter
    {
        public static FactionDtoOut ToRepository(
            FactionDao source
        )
        {
            return new FactionDtoOut(
                id: source.Id,
                name: source.Name,
                color: source.Color,
                ranks: source.Ranks,
                type: FactionTypeDaoConverter.ToRepository(source.Type)
            );
        }
    }
}
