using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
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

        public static TopicDtoOut ToDtoOut(
           ApiTopicDtoIn source,
           int id
        )
        {
            return new TopicDtoOut(
                id: id,
                caption: source.Caption,
                forumId: source.ForumId
            );
        }
    }
}
