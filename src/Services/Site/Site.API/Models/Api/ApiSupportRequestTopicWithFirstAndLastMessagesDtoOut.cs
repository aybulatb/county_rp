namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiSupportRequestTopicWithFirstAndLastMessagesDtoOut
    {
        public ApiSupportRequestTopicDtoOut Topic { get; init; }

        public ApiSupportRequestMessageDtoOut FirstMessage { get; init; }

        public ApiSupportRequestMessageDtoOut LastMessage { get; init; }

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
