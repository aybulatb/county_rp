using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ApiModeratorDtoInConverter
    {
        public static ModeratorDtoIn ToRepository(
            ApiModeratorDtoIn source
        )
        {
            return new ModeratorDtoIn(
                entityId: source.EntityId,
                entityType: source.EntityType,
                forumId: source.ForumId,
                createTopics: source.CreateTopics,
                createPosts: source.CreatePosts,
                read: source.Read,
                editPosts: source.EditPosts,
                deleteTopics: source.DeleteTopics,
                deletePosts: source.DeletePosts
            );
        }
    }
}
