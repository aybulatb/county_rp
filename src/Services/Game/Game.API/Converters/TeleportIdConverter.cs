using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class TeleportIdConverter
    {
        public static TeleportFilterDtoIn ToTeleportFilterDtoIn(
            int source
        )
        {
            return new TeleportFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                name: null,
                nameLike: null,
                factionIds: null,
                gangIds: null,
                roomIds: null,
                businessIds: null
            );
        }
    }
}
