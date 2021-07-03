using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    public static class ApiSupportRequestTopicTypeDtoConverter
    {
        public static SupportRequestTopicTypeDto ToRepository(
            ApiSupportRequestTopicTypeDto source
        )
        {
            return source switch
            {
                ApiSupportRequestTopicTypeDto.Report => SupportRequestTopicTypeDto.Report,
                ApiSupportRequestTopicTypeDto.ReportOnAdmin => SupportRequestTopicTypeDto.ReportOnAdmin,
                ApiSupportRequestTopicTypeDto.Unban => SupportRequestTopicTypeDto.Unban,

                _ => SupportRequestTopicTypeDto.Unknown
            };
        }
    }
}
