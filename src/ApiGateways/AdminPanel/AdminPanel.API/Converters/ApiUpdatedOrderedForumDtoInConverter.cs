using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ApiUpdatedOrderedForumDtoInConverter
    {
        public static ForumUpdatedOrderedForumDtoIn ToService(
            ApiUpdatedOrderedForumDtoIn source
        )
        {
            return new ForumUpdatedOrderedForumDtoIn(
                Id: source.Id,
                ParentId: source.ParentId,
                Order: source.Order
            );
        }
    }
}
