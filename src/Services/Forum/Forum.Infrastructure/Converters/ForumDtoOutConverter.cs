using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
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
    }
}
