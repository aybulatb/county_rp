using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters
{
    internal static class ApiModeratorDtoOutConverter
    {
        public static ForumModeratorDtoOut ToService(
            ApiModeratorDtoOut source
        )
        {
            return new ForumModeratorDtoOut(
                Id: source.Id,
                EntityId: source.EntityId,
                EntityType: (int)source.EntityType,
                ForumId: source.ForumId,
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
