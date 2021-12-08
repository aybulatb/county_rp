using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ForumIdConverter
    {
        public static TopicFilterDtoIn ToTopicFilterDtoIn(
            int source
        )
        {
            return new TopicFilterDtoIn(
                count: null,
                page: null,
                forumId: source
            );
        }

        public static ModeratorFilterDtoIn ToModeratorFilterDtoIn(
            int source
        )
        {
            return new ModeratorFilterDtoIn(
                count: null,
                page: null,
                ids: null,
                entityId: null,
                entityType: null,
                forumId: source
            );
        }

        public static ForumFilterDtoIn ToForumFilterDtoIn(
            int source
        )
        {
            return new ForumFilterDtoIn(
                count: null,
                page: null,
                ids: null,
                parentIds: new[] { source }
            );
        }
    }
}
