using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    public static class ApiSupportRequestTopicFilterDtoInConverter
    {
        public static SupportRequestTopicFilterDtoIn ToRepository(
            ApiSupportRequestTopicFilterDtoIn source
        )
        {
            return new SupportRequestTopicFilterDtoIn(
                count: source.Count,
                page: source.Page,
                type: source.Type != null
                    ? ApiSupportRequestTopicTypeDtoConverter.ToRepository(source.Type.Value)
                    : null,
                status: source.Status != null
                    ? ApiSupportRequestTopicStatusDtoConverter.ToRepository(source.Status.Value)
                    : null,
                creatorUserId: source.CreatorUserId,
                refUserId: source.RefUserId
            );
        }
    }
}
