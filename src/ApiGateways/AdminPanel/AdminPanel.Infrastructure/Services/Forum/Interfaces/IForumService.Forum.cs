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

        Task UpdateForumWithModeratorsAsync(ForumUpdatedForumWithModeratorsDtoIn updatedForumWithModeratorsDtoIn);

        Task UpdateOrderedForumsAsync(IEnumerable<ForumUpdatedOrderedForumDtoIn> updatedOrderedForumsDtoIn);

        Task DeleteForumAsync(int id);
    }
}
