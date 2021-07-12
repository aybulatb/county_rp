using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
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
