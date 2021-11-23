using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ApiModeratorDtoOutConverter
    {
        public static ModeratorDtoOut ToRepository(
            ApiModeratorDtoOut source
        )
        {
            return new ModeratorDtoOut(
                id: source.Id,
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
