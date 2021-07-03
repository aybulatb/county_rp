using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
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

        public static ApiSupportRequestTopicStatusDto ToApi(
            SupportRequestTopicStatusDto source
        )
        {
            return source switch
            {
                SupportRequestTopicStatusDto.New => ApiSupportRequestTopicStatusDto.New,
                SupportRequestTopicStatusDto.Closed => ApiSupportRequestTopicStatusDto.Closed,
                SupportRequestTopicStatusDto.Consideration => ApiSupportRequestTopicStatusDto.Consideration,

                _ => ApiSupportRequestTopicStatusDto.Unknown
            };
        }
    }
}
