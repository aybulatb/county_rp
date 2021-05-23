using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ModeratorDtoOutConverter
    {
        public static ModeratorDao ToDb(
            ModeratorDtoOut source
        )
        {
            return new ModeratorDao(
                id: source.Id,
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
        public static ApiModeratorDtoOut ToApi(
            ModeratorDtoOut source
        )
        {
            return new ApiModeratorDtoOut()
            {
                Id = source.Id,
                EntityId = source.EntityId,
                EntityType = source.EntityType,
                ForumId = source.ForumId,
                CreateTopics = source.CreateTopics,
                CreatePosts = source.CreatePosts,
                Read = source.Read,
                EditPosts = source.EditPosts,
                DeleteTopics = source.DeleteTopics,
                DeletePosts = source.DeletePosts
            };
        }
    }
}
