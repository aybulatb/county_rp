using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumForumWithModeratorsDtoOut(
        int Id,
        string Name,
        IEnumerable<ForumModeratorDtoOut> Moderators
    );
}
