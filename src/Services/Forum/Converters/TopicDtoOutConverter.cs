using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal class TopicDtoOutConverter
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
