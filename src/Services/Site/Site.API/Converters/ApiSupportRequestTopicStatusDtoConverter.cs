using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    public static class ApiSupportRequestTopicStatusDtoConverter
    {
        public static SupportRequestTopicStatusDto ToRepository(
            ApiSupportRequestTopicStatusDto source
        )
        {
            return source switch
            {
                ApiSupportRequestTopicStatusDto.New => SupportRequestTopicStatusDto.New,
                ApiSupportRequestTopicStatusDto.Closed => SupportRequestTopicStatusDto.Closed,
                ApiSupportRequestTopicStatusDto.Consideration => SupportRequestTopicStatusDto.Consideration,

                _ => SupportRequestTopicStatusDto.Unknown
            };
        }
    }
}
