using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ForumModeratorDtoOutConverter
    {
        public static ApiModeratorDtoOut ToApi(
            ForumModeratorDtoOut source
        )
        {
            return new ApiModeratorDtoOut(
                id: source.Id,
                entityId: source.Id,
                entityType: (ApiModeratorEntityTypeDto)source.EntityType,
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
