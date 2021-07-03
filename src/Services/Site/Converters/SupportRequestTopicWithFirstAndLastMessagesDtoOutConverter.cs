using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    public static class SupportRequestTopicWithFirstAndLastMessagesDtoOutConverter
    {
        public static ApiSupportRequestTopicWithFirstAndLastMessagesDtoOut ToApi(
            SupportRequestTopicWithFirstAndLastMessagesDtoOut source
        )
        {
            return new ApiSupportRequestTopicWithFirstAndLastMessagesDtoOut(
                topic: SupportRequestTopicDtoOutConverter.ToApi(source.Topic),
                firstMessage: SupportRequestMessageDtoOutConverter.ToApi(source.FirstMessage),
                lastMessage: SupportRequestMessageDtoOutConverter.ToApi(source.LastMessage)
            );
        }
    }
}
