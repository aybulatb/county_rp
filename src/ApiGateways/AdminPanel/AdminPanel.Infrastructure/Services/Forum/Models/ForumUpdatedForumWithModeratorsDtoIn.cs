using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumUpdatedForumWithModeratorsDtoIn(
        string Name,
        int ParentId,
        int Order,
        IEnumerable<ForumModeratorDtoOut> Moderators
    );
}
