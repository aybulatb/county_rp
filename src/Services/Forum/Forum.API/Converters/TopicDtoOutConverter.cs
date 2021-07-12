using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class TopicDtoOutConverter
    {
        public static ApiTopicDtoOut ToApi(
            TopicDtoOut source
        )
        {
            return new ApiTopicDtoOut()
            {
                Id = source.Id,
                Caption = source.Caption,
                ForumId = source.ForumId
            };
        }
    }
}
