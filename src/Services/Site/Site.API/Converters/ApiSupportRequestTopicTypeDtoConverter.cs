using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
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
