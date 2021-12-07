using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces
{
    public partial interface IForumService
    {
        Task<ForumForumDtoOut> CreateForumAsync(ForumForumDtoIn forumDtoIn);

        Task<ForumForumDtoOut> GetForumAsync(int id);

        Task<IEnumerable<ForumHierarchicalForumDtoOut>> GetHierarchicalForumsAsync();

        Task UpdateForumAsync(int id, ForumForumDtoIn forumDtoIn);

        Task UpdateOrderedForumsAsync(IEnumerable<ForumUpdatedOrderedForumDtoIn> updatedOrderedForumsDtoIn);

        Task DeleteForumAsync(int id);

        Task<bool> ValidateForumAsync(ForumForumDtoIn forumDtoIn);
    }
}
