using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal class ApiModeratorFilterDtoInConverter
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
