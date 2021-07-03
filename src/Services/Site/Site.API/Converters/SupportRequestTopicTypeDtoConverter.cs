using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    public static class SupportRequestTopicTypeDtoConverter
    {
        public static ApiSupportRequestTopicTypeDto ToApi(
            SupportRequestTopicTypeDto source
        )
        {
            return source switch
            {
                SupportRequestTopicTypeDto.Report => ApiSupportRequestTopicTypeDto.Report,
                SupportRequestTopicTypeDto.ReportOnAdmin => ApiSupportRequestTopicTypeDto.ReportOnAdmin,
                SupportRequestTopicTypeDto.Unban => ApiSupportRequestTopicTypeDto.Unban,

                _ => ApiSupportRequestTopicTypeDto.Unknown
            };
        }
    }
}
