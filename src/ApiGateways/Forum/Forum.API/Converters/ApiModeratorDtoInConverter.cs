using CountyRP.ApiGateways.Forum.API.Models;
using CountyRP.ApiGateways.Forum.Infrastructure.Models;

namespace CountyRP.ApiGateways.Forum.API.Converters
{
    internal static class ApiModeratorDtoInConverter
    {
        public static ModeratorDtoIn ToService(
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
