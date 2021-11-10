using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record SupportRequestTopicDtoOut(
        int Id,
        SupportRequestTopicTypeDto Type,
        string Caption,
        SupportRequestTopicStatusDto Status,
        int CreatorUserId,
        DateTimeOffset CreationDate,
        int? RefUserId,
        bool ShowRefUser
    );
}
