using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class ModeratorDtoInConverter
    {
        public static ModeratorDao ToDb(
            ModeratorDtoIn source
        )
        {
            return new ModeratorDao(
                id: 0,
                entityId: source.EntityId,
                entityType: ModeratorEntityTypeDtoConverter.ToDb(source.EntityType),
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
            ModeratorDtoIn source,
            int id
        )
        {
            return new ModeratorDtoOut(
                id: id,
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
