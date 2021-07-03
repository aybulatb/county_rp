using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    public class SupportRequestTopicStatusDtoConverter
    {
        public static SupportRequestTopicStatusDao ToDb(
            SupportRequestTopicStatusDto source
        )
        {
            return source switch
            {
                SupportRequestTopicStatusDto.New => SupportRequestTopicStatusDao.New,
                SupportRequestTopicStatusDto.Closed => SupportRequestTopicStatusDao.Closed,
                SupportRequestTopicStatusDto.Consideration => SupportRequestTopicStatusDao.Consideration,

                _ => SupportRequestTopicStatusDao.Unknown
            };
        }
    }
}
