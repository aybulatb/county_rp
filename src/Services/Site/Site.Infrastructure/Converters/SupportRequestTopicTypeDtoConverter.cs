using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
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
    }
}
