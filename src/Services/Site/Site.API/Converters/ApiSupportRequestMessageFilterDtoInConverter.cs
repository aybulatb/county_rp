using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    public static class ApiSupportRequestMessageFilterDtoInConverter
    {
        public static SupportRequestMessageFilterDtoIn ToRepository(
            ApiSupportRequestMessageFilterDtoIn source
        )
        {
            return new SupportRequestMessageFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                topicId: source.TopicId,
                userId: source.UserId
            );
        }
    }
}
