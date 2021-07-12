using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ForumDtoOutConverter
    {
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
