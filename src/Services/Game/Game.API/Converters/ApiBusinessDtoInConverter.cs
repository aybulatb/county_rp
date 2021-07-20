using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiBusinessDtoInConverter
    {
        public static BusinessDtoIn ToRepository(
            ApiBusinessDtoIn source
        )
        {
            return new BusinessDtoIn(
                name: source.Name,
                entrancePosition: source.EntrancePosition,
                entranceDimension: source.EntranceDimension,
                exitPosition: source.ExitPosition,
                exitDimension: source.ExitDimension,
                ownerId: source.OwnerId,
                lockDoors: source.LockDoors,
                type: ApiBusinessTypeDtoConverter.ToRepository(source.Type),
                price: source.Price
            );
        }
    }
}
