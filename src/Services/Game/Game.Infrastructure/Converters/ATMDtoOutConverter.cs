using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class ATMDtoOutConverter
    {
        public static ATMDao ToDb(
            ATMDtoOut source
        )
        {
            return new ATMDao(
                id: source.Id,
                position: source.Position,
                dimension: source.Dimension,
                businessId: source.BusinessId
            );
        }
    }
}
