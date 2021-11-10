using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record SupportRequestTopicDtoIn(
        SupportRequestTopicTypeDto Type,
        string Caption,
        SupportRequestTopicStatusDto Status,
        int CreatorUserId,
        DateTimeOffset CreationDate,
        int? RefUserId,
        bool ShowRefUser
    );
}
