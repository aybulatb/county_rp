using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ApiModeratorFilterDtoInConverter
    {
        public static ModeratorFilterDtoIn ToRepository(
            ApiModeratorFilterDtoIn source
        )
        {
            return new ModeratorFilterDtoIn(
                count: source.Count,
                page: source.Page,
                entityId: source.EntityId,
                entityType: source.EntityType,
                forumId: source.ForumId
            );
        }
    }
}
