using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters
{
    internal static class ForumForumDtoInConverter
    {
        public static ApiForumDtoIn ToExternalApi(
            ForumForumDtoIn source
        )
        {
            return new ApiForumDtoIn
            {
                Name = source.Name,
                ParentId = source.ParentId,
                Order = source.Order
            };
        }
    }
}
