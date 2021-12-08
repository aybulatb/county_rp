using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ApiModeratorDtoInConverter
    {
        public static ForumModeratorDtoIn ToService(
            ApiModeratorDtoIn source,
            int forumId
        )
        {
            return new ForumModeratorDtoIn(
                EntityId: source.EntityId,
                EntityType: ApiModeratorEntityTypeDtoConverter.ToService(source.EntityType),
                ForumId: forumId,
                CreateTopics: source.CreateTopics,
                CreatePosts: source.CreatePosts,
                Read: source.Read,
                EditPosts: source.EditPosts,
                DeleteTopics: source.DeleteTopics,
                DeletePosts: source.DeletePosts
            );
        }
    }
}
