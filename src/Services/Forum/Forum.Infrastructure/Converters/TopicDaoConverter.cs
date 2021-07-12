using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class TopicDaoConverter
    {
        public static TopicDtoOut ToRepository(
            TopicDao source
        )
        {
            return new TopicDtoOut(
                id: source.Id,
                caption: source.Caption,
                forumId: source.ForumId
            );
        }
    }
}
