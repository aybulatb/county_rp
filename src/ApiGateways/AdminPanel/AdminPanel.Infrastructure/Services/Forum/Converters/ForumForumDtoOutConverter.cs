using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters
{
    internal static class ForumForumDtoOutConverter
    {
        public static ApiForumDtoOut ToExternalApi(
            ForumForumDtoOut source
        )
        {
            return new ApiForumDtoOut
            {
                Id = source.Id,
                Name = source.Name,
                ParentId = source.ParentId,
                Order = source.Order
            };
        }
    }
}
