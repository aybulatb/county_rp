using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ApiForumFilterDtoInConverter
    {
        public static ForumFilterDtoIn ToRepository(
            ApiForumFilterDtoIn source
        )
        {
            return new ForumFilterDtoIn(
                count: source.Count,
                page: source.Page,
                parentId: source.ParentId
            );
        }
    }
}
