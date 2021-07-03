using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
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
