using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record SupportRequestMessageDtoOut(
        int Id,
        int TopicId,
        string Text,
        int UserId,
        DateTimeOffset CreationDate,
        DateTimeOffset? EditionDate
    );
}
