using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters
{
    internal static class ApiForumDtoOutConverter
    {
        public static ForumForumDtoOut ToService(
            ApiForumDtoOut source
        )
        {
            return new ForumForumDtoOut(
                Id: source.Id,
                Name: source.Name,
                ParentId: source.ParentId,
                Order: source.Order
            );
        }
    }
}
