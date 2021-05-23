using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ApiTopicDtoInConverter
    {
        public static TopicDtoIn ToRepository(
            ApiTopicDtoIn source
        )
        {
            return new TopicDtoIn(
                caption: source.Caption,
                forumId: source.ForumId
            );
        }
    }
}
