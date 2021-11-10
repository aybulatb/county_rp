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
                Count: source.Count,
                Page: source.Page,
                Ids: source.Ids,
                TopicId: source.TopicId,
                UserId: source.UserId
            );
        }
    }
}
