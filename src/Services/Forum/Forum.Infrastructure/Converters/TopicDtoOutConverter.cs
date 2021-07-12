using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class TopicDtoOutConverter
    {
        public static TopicDao ToDb(
            TopicDtoOut source
        )
        {
            return new TopicDao(
                id: source.Id,
                caption: source.Caption,
                forumId: source.ForumId
            );
        }
    }
}
