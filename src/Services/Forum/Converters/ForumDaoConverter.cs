using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ForumDaoConverter
    {
        public static ForumDtoOut ToRepository(
            ForumDao source
        )
        {
            return new ForumDtoOut(
                id: source.Id,
                name: source.Name,
                parentId: source.ParentId,
                order: source.Order
            );
        }
    }
}
