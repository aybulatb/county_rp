using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class BusinessDtoOutConverter
    {
        public static BusinessDao ToDb(
            BusinessDtoOut source
        )
        {
            return new BusinessDao(
                id: source.Id,
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
