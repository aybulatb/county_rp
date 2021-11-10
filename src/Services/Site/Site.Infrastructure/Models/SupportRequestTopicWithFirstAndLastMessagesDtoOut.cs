namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record SupportRequestTopicWithFirstAndLastMessagesDtoOut(
        SupportRequestTopicDtoOut Topic,
        SupportRequestMessageDtoOut FirstMessage,
        SupportRequestMessageDtoOut LastMessage
    );
}
