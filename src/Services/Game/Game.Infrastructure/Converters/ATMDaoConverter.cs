using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class ATMDaoConverter
    {
        public static ATMDtoOut ToRepository(
            ATMDao source
        )
        {
            return new ATMDtoOut(
                id: source.Id,
                position: source.Position,
                dimension: source.Dimension,
                businessId: source.BusinessId
            );
        }
    }
}
