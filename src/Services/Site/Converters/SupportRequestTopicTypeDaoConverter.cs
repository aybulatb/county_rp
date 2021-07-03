using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
{
    public static class SupportRequestTopicTypeDaoConverter
    {
        public static SupportRequestTopicTypeDto ToRepository(
            SupportRequestTopicTypeDao source
        )
        {
            return source switch
            {
                SupportRequestTopicTypeDao.Report => SupportRequestTopicTypeDto.Report,
                SupportRequestTopicTypeDao.ReportOnAdmin => SupportRequestTopicTypeDto.ReportOnAdmin,
                SupportRequestTopicTypeDao.Unban => SupportRequestTopicTypeDto.Unban,

                _ => SupportRequestTopicTypeDto.Unknown
            };
        }
    }
}
