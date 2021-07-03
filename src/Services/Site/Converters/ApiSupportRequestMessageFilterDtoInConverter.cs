using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
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
