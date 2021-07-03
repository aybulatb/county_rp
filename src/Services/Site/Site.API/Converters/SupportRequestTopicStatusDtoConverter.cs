using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    public class SupportRequestTopicStatusDtoConverter
    {
        public static ApiSupportRequestTopicStatusDto ToApi(
            SupportRequestTopicStatusDto source
        )
        {
            return source switch
            {
                SupportRequestTopicStatusDto.New => ApiSupportRequestTopicStatusDto.New,
                SupportRequestTopicStatusDto.Closed => ApiSupportRequestTopicStatusDto.Closed,
                SupportRequestTopicStatusDto.Consideration => ApiSupportRequestTopicStatusDto.Consideration,

                _ => ApiSupportRequestTopicStatusDto.Unknown
            };
        }
    }
}
