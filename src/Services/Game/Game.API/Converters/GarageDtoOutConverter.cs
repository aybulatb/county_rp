using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class GarageDtoOutConverter
    {
        public static ApiGarageDtoOut ToApi(
            GarageDtoOut source
        )
        {
            return new ApiGarageDtoOut(
                id: source.Id,
                type: source.Type,
                entrancePosition: source.EntrancePosition,
                entranceDimension: source.EntranceDimension,
                entranceRotation: source.EntranceRotation,
                exitDimension: source.ExitDimension,
                lockDoors: source.LockDoors
            );
        }
    }
}
