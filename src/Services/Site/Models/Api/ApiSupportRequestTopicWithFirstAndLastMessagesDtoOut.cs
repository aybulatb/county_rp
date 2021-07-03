namespace CountyRP.Services.Site.Models.Api
{
    public class ApiSupportRequestTopicWithFirstAndLastMessagesDtoOut
    {
        public ApiSupportRequestTopicDtoOut Topic { get; }

        public ApiSupportRequestMessageDtoOut FirstMessage { get; }

        public ApiSupportRequestMessageDtoOut LastMessage { get; }

        public ApiSupportRequestTopicWithFirstAndLastMessagesDtoOut(
            ApiSupportRequestTopicDtoOut topic,
            ApiSupportRequestMessageDtoOut firstMessage,
            ApiSupportRequestMessageDtoOut lastMessage
        )
        {
            Topic = topic;
            FirstMessage = firstMessage;
            LastMessage = lastMessage;
        }
    }
}
