using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ForumDtoOutConverter
    {
        public static ForumDao ToDb(
            ForumDtoOut source
        )
        {
            return new ForumDao(
                id: source.Id,
                name: source.Name,
                parentId: source.ParentId,
                order: source.Order
            );
        }

        public static ApiForumDtoOut ToApi(
            ForumDtoOut source
        )
        {
            return new ApiForumDtoOut()
            {
                Id = source.Id,
                Name = source.Name,
                ParentId = source.ParentId,
                Order = source.Order
            };
        }
    }
}
