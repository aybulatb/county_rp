using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ApiTopicFilterDtoInConverter
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
