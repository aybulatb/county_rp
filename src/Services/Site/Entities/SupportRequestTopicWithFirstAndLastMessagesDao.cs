namespace CountyRP.Services.Site.Entities
{
    public class SupportRequestTopicWithFirstAndLastMessagesDao
    {
        public SupportRequestTopicDao Topic { get; set; }

        public SupportRequestMessageDao FirstMessage { get; set; }

        public SupportRequestMessageDao LastMessage { get; set; }
    }
}
