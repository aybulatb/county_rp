using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class ForumDtoInConverter
    {
        public static ForumDao ToDb(
            ForumDtoIn source
        )
        {
            return new ForumDao(
                id: 0,
                name: source.Name,
                parentId: source.ParentId,
                order: source.Order
            );
        }

        public static ForumDtoOut ToDtoOut(
            ForumDtoIn source,
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
