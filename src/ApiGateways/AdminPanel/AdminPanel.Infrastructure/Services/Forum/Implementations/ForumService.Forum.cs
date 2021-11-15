using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Implementations
{
    public partial class ForumService
    {
        public async Task<ForumForumWithModeratorsDtoOut> CreateForumWithModeratorsAsync(ForumForumWithModeratorsDtoIn forumWithModeratorsDtoIn)
        {
            return null;
        }

        public async Task<ForumForumWithModeratorsDtoOut> GetForumWithModeratorsByIdAsync(int id)
        {
            return null;
        }

        public async Task<IEnumerable<ForumHierarchicalForumDtoOut>> GetHierarchicalForumsAsync()
        {
            return null;
        }

        public async Task<ForumForumWithModeratorsDtoOut> UpdateForumWithModeratorsAsync(ForumUpdatedForumWithModeratorsDtoIn updatedForumWithModeratorsDtoIn)
        {
            return null;
        }

        public async Task DeleteForumAsync(int id)
        {
            await _forumClient.DeleteAsync(id);
        }
    }
}
