using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record SupportRequestMessageDtoIn(
        int TopicId,
        string Text,
        int UserId,
        DateTimeOffset CreationDate,
        DateTimeOffset? EditionDate
    );
}
