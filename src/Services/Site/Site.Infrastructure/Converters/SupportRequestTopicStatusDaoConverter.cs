using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    public class SupportRequestTopicStatusDaoConverter
    {
        public static SupportRequestTopicStatusDto ToRepository(
            SupportRequestTopicStatusDao source
        )
        {
            return source switch
            {
                SupportRequestTopicStatusDao.New => SupportRequestTopicStatusDto.New,
                SupportRequestTopicStatusDao.Closed => SupportRequestTopicStatusDto.Closed,
                SupportRequestTopicStatusDao.Consideration => SupportRequestTopicStatusDto.Consideration,

                _ => SupportRequestTopicStatusDto.Unknown
            };
        }
    }
}
