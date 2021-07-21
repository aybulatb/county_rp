using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class AtmDtoInConverter
    {
        public static AtmDao ToDb(
            AtmDtoIn source
        )
        {
            return new AtmDao(
                id: 0,
                position: source.Position,
                dimension: source.Dimension,
                businessId: source.BusinessId
            );
        }
    }
}
