using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class BusinessDaoConverter
    {
        public static BusinessDtoOut ToRepository(
            BusinessDao source
        )
        {
            return new BusinessDtoOut(
                id: source.Id,
                name: source.Name,
                entrancePosition: source.EntrancePosition,
                entranceDimension: source.EntranceDimension,
                exitPosition: source.ExitPosition,
                exitDimension: source.ExitDimension,
                ownerId: source.OwnerId,
                lockDoors: source.LockDoors,
                type: BusinessTypeDaoConverter.ToRepository(source.Type),
                price: source.Price
            );
        }
    }
}
