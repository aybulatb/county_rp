using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class TopicDtoInConverter
    {
        public static TopicDao ToDb(
            TopicDtoIn source
        )
        {
            return new TopicDao(
                id: 0,
                caption: source.Caption,
                forumId: source.ForumId
            );
        }

        public static TopicDtoOut ToDtoOut(
            TopicDtoIn source,
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
