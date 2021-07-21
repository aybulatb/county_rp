using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class AtmDtoOutConverter
    {
        public static AtmDao ToDb(
            AtmDtoOut source
        )
        {
            return new AtmDao(
                id: source.Id,
                position: source.Position,
                dimension: source.Dimension,
                businessId: source.BusinessId
            );
        }
    }
}
