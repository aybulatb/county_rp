using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ApiForumDtoInConverter
    {
        public static ForumDtoIn ToRepository(
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
