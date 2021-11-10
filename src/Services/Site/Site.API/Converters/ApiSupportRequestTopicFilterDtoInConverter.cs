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
                Count: source.Count,
                Page: source.Page,
                Type: source.Type != null
                    ? ApiSupportRequestTopicTypeDtoConverter.ToRepository(source.Type.Value)
                    : null,
                Status: source.Status != null
                    ? ApiSupportRequestTopicStatusDtoConverter.ToRepository(source.Status.Value)
                    : null,
                CreatorUserId: source.CreatorUserId,
                RefUserId: source.RefUserId
            );
        }
    }
}
