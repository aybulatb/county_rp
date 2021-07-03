using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
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
