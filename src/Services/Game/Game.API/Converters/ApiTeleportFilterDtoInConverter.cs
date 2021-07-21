using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiTeleportFilterDtoInConverter
    {
        public static TeleportFilterDtoIn ToRepository(
            ApiTeleportFilterDtoIn source
        )
        {
            return new TeleportFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                name: source.Name,
                nameLike: source.NameLike,
                factionIds: source.FactionIds,
                gangIds: source.GangIds,
                roomIds: source.RoomIds,
                businessIds: source.BusinessIds
            );
        }
    }
}
