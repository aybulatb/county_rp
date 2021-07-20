using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class BusinessDtoOutConverter
    {
        public static ApiBusinessDtoOut ToApi(
            BusinessDtoOut source
        )
        {
            return new ApiBusinessDtoOut(
                id: source.Id,
                name: source.Name,
                entrancePosition: source.EntrancePosition,
                entranceDimension: source.EntranceDimension,
                exitPosition: source.ExitPosition,
                exitDimension: source.ExitDimension,
                ownerId: source.OwnerId,
                lockDoors: source.LockDoors,
                type: BusinessTypeDtoConverter.ToApi(source.Type),
                price: source.Price
            );
        }
    }
}
