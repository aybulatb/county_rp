using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters
{
    internal static class ForumUpdatedOrderedForumDtoInConverter
    {
        public static ApiUpdatedOrderedForumDtoIn ToExternalApi(
            ForumUpdatedOrderedForumDtoIn source
        )
        {
            return new ApiUpdatedOrderedForumDtoIn()
            {
                Id = source.Id,
                Order = source.Order,
                ParentId = source.ParentId
            };
        }
    }
}
