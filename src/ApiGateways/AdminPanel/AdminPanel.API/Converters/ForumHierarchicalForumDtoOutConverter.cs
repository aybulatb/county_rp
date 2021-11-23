using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ForumHierarchicalForumDtoOutConverter
    {
        public static ApiForumHierarchicalForumDtoOut ToApi(
            ForumHierarchicalForumDtoOut source
        )
        {
            return new ApiForumHierarchicalForumDtoOut(
                id: source.Id,
                name: source.Name,
                parentId: source.ParentId,
                order: source.Order,
                childForums: source.ChildForums
                    ?.Select(ForumHierarchicalForumDtoOutConverter.ToApi)
            );
        }
    }
}
