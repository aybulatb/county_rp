using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
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

        public static ForumDtoOut ToDtoOut(
           ApiForumDtoIn source,
           int id
        )
        {
            return new ForumDtoOut(
                id: id,
                name: source.Name,
                parentId: source.ParentId,
                order: source.Order
            );
        }
    }
}
