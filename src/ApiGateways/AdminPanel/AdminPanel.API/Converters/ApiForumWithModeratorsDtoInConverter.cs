using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ApiForumWithModeratorsDtoInConverter
    {
        public static ForumForumDtoIn ToService(
            ApiForumWithModeratorsDtoIn source
        )
        {
            return new ForumForumDtoIn(
                Name: source.Name,
                ParentId: source.ParentId,
                Order: source.Order
            );
        }
    }
}
