using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters.User
{
    internal static class UserIdConverter
    {
        public static ModeratorFilterDtoIn ToModeratorFilterDtoIn(
            int source
        )
        {
            return new ModeratorFilterDtoIn(
                count: null,
                page: null,
                ids: null,
                entityId: source,
                entityType: 2,
                forumId: null
            );
        }
    }
}
