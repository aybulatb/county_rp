using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class ATMDtoInConverter
    {
        public static ATMDao ToDb(
            ATMDtoIn source
        )
        {
            return new ATMDao(
                id: 0,
                position: source.Position,
                dimension: source.Dimension,
                businessId: source.BusinessId
            );
        }
    }
}
