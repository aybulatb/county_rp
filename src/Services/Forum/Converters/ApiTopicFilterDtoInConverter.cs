using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    public class ApiTopicFilterDtoInConverter
    {
        public static TopicFilterDtoIn ToRepository(
            ApiTopicFilterDtoIn source
        )
        {
            return new TopicFilterDtoIn(
                count: source.Count,
                page: source.Page,
                forumId: source.ForumId
            );
        }
    }
}
