using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces
{
    public partial interface IForumService
    {
        Task<ForumForumWithModeratorsDtoOut> CreateForumWithModeratorsAsync(ForumForumWithModeratorsDtoIn forumWithModeratorsDtoIn);

        Task<ForumForumWithModeratorsDtoOut> GetForumWithModeratorsByIdAsync(int id);

        Task<IEnumerable<ForumHierarchicalForumDtoOut>> GetHierarchicalForumsAsync();

        Task<ForumForumWithModeratorsDtoOut> UpdateForumWithModeratorsAsync(ForumUpdatedForumWithModeratorsDtoIn updatedForumWithModeratorsDtoIn);

        Task DeleteForumAsync(int id);
    }
}
