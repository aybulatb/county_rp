using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ApiModeratorDtoInConverter
    {
        public static ModeratorDtoIn ToRepository(
            ApiModeratorDtoIn source
        )
        {
            return new ModeratorDtoIn(
                entityId: source.EntityId,
                entityType: ApiModeratorEntityTypeDtoConverter.ToRepository(source.EntityType),
                forumId: source.ForumId,
                createTopics: source.CreateTopics,
                createPosts: source.CreatePosts,
                read: source.Read,
                editPosts: source.EditPosts,
                deleteTopics: source.DeleteTopics,
                deletePosts: source.DeletePosts
            );
        }

        public static ModeratorDtoOut ToDtoOut(
           ApiModeratorDtoIn source,
           int id
        )
        {
            return new ModeratorDtoOut(
                id: id,
                entityId: source.EntityId,
                entityType: ApiModeratorEntityTypeDtoConverter.ToRepository(source.EntityType),
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
