using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;
using System.Linq;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class HierarchicalForumDtoOutConverter
    {
        public static ApiHierarchicalForumDtoOut ToApi(
            HierarchicalForumDtoOut source
        )
        {
            return new ApiHierarchicalForumDtoOut(
                id: source.Id,
                name: source.Name,
                parentId: source.ParentId,
                order: source.Order,
                childForums: source.ChildForums
                    .Select(HierarchicalForumDtoOutConverter.ToApi)
                    .ToList()
            );
        }
    }
}
