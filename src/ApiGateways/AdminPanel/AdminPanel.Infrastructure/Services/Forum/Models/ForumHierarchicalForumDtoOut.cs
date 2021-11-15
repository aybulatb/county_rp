using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumHierarchicalForumDtoOut(
        int Id,
        string Name,
        int ParentId,
        int Order,
        IEnumerable<ForumHierarchicalForumDtoOut> ChildForums
    );
}
