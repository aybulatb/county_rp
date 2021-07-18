using CountyRP.ApiGateways.Forum.API.Models;
using CountyRP.ApiGateways.Forum.Infrastructure.Models;

namespace CountyRP.ApiGateways.Forum.API.Converters
{
    internal static class ApiForumDtoInConverter
    {
        public static ForumDtoIn ToService(
            ApiForumDtoIn source
        )
        {
            return new ForumDtoIn(
                name: source.Name,
                parentId: source.ParentId,
                order: source.Order
            );
        }
    }
}
