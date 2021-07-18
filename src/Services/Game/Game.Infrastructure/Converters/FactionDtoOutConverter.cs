using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class FactionDtoOutConverter
    {
        public static FactionDao ToDb(
            FactionDtoOut source
        )
        {
            return new FactionDao(
                id: source.Id,
                name: source.Name,
                color: source.Color,
                ranks: source.Ranks,
                type: FactionTypeDtoConverter.ToDb(source.Type)
            );
        }
    }
}
