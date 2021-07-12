using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
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
