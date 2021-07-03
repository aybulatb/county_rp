using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    public static class SupportRequestTopicTypeDtoConverter
    {
        public static SupportRequestTopicTypeDao ToDb(
            SupportRequestTopicTypeDto source
        )
        {
            return source switch
            {
                SupportRequestTopicTypeDto.Report => SupportRequestTopicTypeDao.Report,
                SupportRequestTopicTypeDto.ReportOnAdmin => SupportRequestTopicTypeDao.ReportOnAdmin,
                SupportRequestTopicTypeDto.Unban => SupportRequestTopicTypeDao.Unban,

                _ => SupportRequestTopicTypeDao.Unknown
            };
        }

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
