using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class BusinessDtoInConverter
    {
        public static BusinessDao ToDb(
            BusinessDtoIn source
        )
        {
            return new BusinessDao(
                id: 0,
                name: source.Name,
                entrancePosition: source.EntrancePosition,
                entranceDimension: source.EntranceDimension,
                exitPosition: source.ExitPosition,
                exitDimension: source.ExitDimension,
                ownerId: source.OwnerId,
                lockDoors: source.LockDoors,
                type: BusinessTypeDtoConverter.ToDb(source.Type),
                price: source.Price
            );
        }
    }
}
