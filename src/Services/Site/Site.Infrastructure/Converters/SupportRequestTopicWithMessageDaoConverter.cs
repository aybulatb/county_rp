using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    public static class SupportRequestTopicWithMessageDaoConverter
    {
        public static SupportRequestTopicWithFirstAndLastMessagesDtoOut ToRepository(
            SupportRequestTopicWithFirstAndLastMessagesDao source
        )
        {
            return new SupportRequestTopicWithFirstAndLastMessagesDtoOut(
                Topic: SupportRequestTopicDaoConverter.ToRepository(source.Topic),
                FirstMessage: SupportRequestMessageDaoConverter.ToRepository(source.FirstMessage),
                LastMessage: SupportRequestMessageDaoConverter.ToRepository(source.LastMessage)
            );
        }
    }
}
