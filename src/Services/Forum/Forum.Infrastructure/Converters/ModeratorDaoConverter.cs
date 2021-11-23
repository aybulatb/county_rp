using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class ModeratorDaoConverter
    {
        public static ModeratorDtoOut ToRepository(
            ModeratorDao source
        )
        {
            return new ModeratorDtoOut(
                id: source.Id,
                entityId: source.EntityId,
                entityType: ModeratorEntityTypeDaoConverter.ToRepository(source.EntityType),
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
