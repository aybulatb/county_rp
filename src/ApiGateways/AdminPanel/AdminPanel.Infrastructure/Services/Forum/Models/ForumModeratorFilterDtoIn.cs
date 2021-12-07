using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumModeratorFilterDtoIn(
        int? Count,
        int? Page,
        IEnumerable<int> Ids,
        int? EntityId,
        ForumModeratorEntityTypeDto? EntityType,
        int? ForumId
    ) : ForumPagedFilterDtoIn(Count, Page);
}
