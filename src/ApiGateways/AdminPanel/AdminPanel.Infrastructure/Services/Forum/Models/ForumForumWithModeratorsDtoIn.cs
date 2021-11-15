using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumForumWithModeratorsDtoIn(
        string Name,
        int ParentId,
        int Order,
        IEnumerable<ForumModeratorDtoIn> Moderators
    );
}
