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
                topic: SupportRequestTopicDaoConverter.ToRepository(source.Topic),
                firstMessage: SupportRequestMessageDaoConverter.ToRepository(source.FirstMessage),
                lastMessage: SupportRequestMessageDaoConverter.ToRepository(source.LastMessage)
            );
        }
    }
}
