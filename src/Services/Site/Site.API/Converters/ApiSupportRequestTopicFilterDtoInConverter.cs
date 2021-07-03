using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
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
