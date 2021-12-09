using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ForumModeratorDtoOutConverter
    {
        public static ApiModeratorDtoOut ToApi(
            ForumModeratorDtoOut source,
            string name
        )
        {
            return new ApiModeratorDtoOut(
                id: source.Id,
                entityId: source.EntityId,
                entityType: (ApiModeratorEntityTypeDto)source.EntityType,
                name: name,
                forumId: source.ForumId,
                createTopics: source.CreateTopics,
                createPosts: source.CreatePosts,
                read: source.Read,
                editPosts: source.EditPosts,
                deleteTopics: source.DeleteTopics,
                deletePosts: source.DeletePosts
            );
        }

        public static ForumModeratorDtoOut ToUpdatedForumModeratorDtoOut(
            ForumModeratorDtoOut source,
            ApiUpdatedModeratorDtoIn updatedModerator
        )
        {
            return new ForumModeratorDtoOut(
                Id: source.Id,
                EntityId: source.EntityId,
                EntityType: source.EntityType,
                ForumId: source.ForumId,
                CreateTopics: updatedModerator.CreateTopics,
                CreatePosts: updatedModerator.CreatePosts,
                Read: updatedModerator.Read,
                EditPosts: updatedModerator.EditPosts,
                DeleteTopics: updatedModerator.DeleteTopics,
                DeletePosts: updatedModerator.DeletePosts
            );
        }
    }
}
