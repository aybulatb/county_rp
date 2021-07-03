namespace CountyRP.Services.Site.Infrastructure.Models
{
    public class SupportRequestTopicWithFirstAndLastMessagesDtoOut
    {
        public SupportRequestTopicDtoOut Topic { get; }

        public SupportRequestMessageDtoOut FirstMessage { get; }

        public SupportRequestMessageDtoOut LastMessage { get; }

        public SupportRequestTopicWithFirstAndLastMessagesDtoOut(
            SupportRequestTopicDtoOut topic,
            SupportRequestMessageDtoOut firstMessage,
            SupportRequestMessageDtoOut lastMessage
        )
        {
            Topic = topic;
            FirstMessage = firstMessage;
            LastMessage = lastMessage;
        }
    }
}
