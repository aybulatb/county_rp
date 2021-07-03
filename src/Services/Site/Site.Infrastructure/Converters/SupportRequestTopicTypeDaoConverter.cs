using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
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
