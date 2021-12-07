using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ApiUpdatedOrderedForumDtoInConverter
    {
        public static ForumDtoOut ToForumDtoOut(
            ApiUpdatedOrderedForumDtoIn source
        )
        {
            return new ForumDtoOut(
                id: source.Id,
                name: string.Empty,
                parentId: source.ParentId,
                order: source.Order
            );
        }
    }
}
