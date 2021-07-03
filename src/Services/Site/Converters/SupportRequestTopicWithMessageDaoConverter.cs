using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
{
    public static class SupportRequestTopicWithMessageDaoConverter
    {
        public static SupportRequestTopicWithFirstAndLastMessagesDtoOut ToRepository(
            SupportRequestTopicWithFirstAndLastMessagesDao source
        )
        {
            return new SupportRequestTopicWithFirstAndLastMessagesDtoOut(
                topic: SupportRequestTopicDaoConverter.ToRepository(source.Topic),
                firstMessage: SupportRequestMessageDaoConverter.ToRepository(source.FirstMessage),
                lastMessage: SupportRequestMessageDaoConverter.ToRepository(source.LastMessage)
            );
        }
    }
}
