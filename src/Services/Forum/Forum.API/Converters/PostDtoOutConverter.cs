using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class PostDtoOutConverter
    {
        public static ApiPostDtoOut ToApi(
            PostDtoOut source
        )
        {
            return new ApiPostDtoOut()
            {
                Id = source.Id,
                Text = source.Text,
                TopicId = source.TopicId,
                UserId = source.UserId,
                LastEditorId = source.LastEditorid,
                CreationDateTime = source.CreationDateTime,
                EditionDateTime = source.EditionDateTime
            };
        }
    }
}
