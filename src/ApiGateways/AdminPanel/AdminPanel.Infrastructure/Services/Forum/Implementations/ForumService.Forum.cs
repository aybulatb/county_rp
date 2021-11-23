using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Collections.Generic;
using System.Linq;
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
            var apiHierarchicalForums = await _forumClient.GetHierarchicalAsync();

            return apiHierarchicalForums
                .Select(ApiHierarchicalForumDtoOutConverter.ToService);
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
