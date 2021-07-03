using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
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
