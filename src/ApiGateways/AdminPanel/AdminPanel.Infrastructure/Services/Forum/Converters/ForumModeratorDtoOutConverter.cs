using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters
{
    internal static class ForumModeratorDtoOutConverter
    {
        public static ApiModeratorDtoOut ToExternalApi(
            ForumModeratorDtoOut source
        )
        {
            return new ApiModeratorDtoOut
            {
                Id = source.Id,
                EntityId = source.EntityId,
                EntityType = (ApiModeratorEntityTypeDto)source.EntityType,
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
