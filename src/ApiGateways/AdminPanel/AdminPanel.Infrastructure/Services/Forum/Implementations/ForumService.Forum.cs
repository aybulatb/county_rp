using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Implementations
{
    public partial class ForumService
    {
        public async Task<ForumForumDtoOut> CreateForumAsync(ForumForumDtoIn forumDtoIn)
        {
            var apiForumDtoIn = ForumForumDtoInConverter.ToExternalApi(forumDtoIn);

            var apiForumDtoOut = await _forumClient.CreateAsync(apiForumDtoIn);

            return ApiForumDtoOutConverter.ToService(apiForumDtoOut);
        }

        public async Task<ForumForumDtoOut> GetForumAsync(int id)
        {
            var apiForumDtoOut = await _forumClient.GetByIdAsync(id);

            return ApiForumDtoOutConverter.ToService(apiForumDtoOut);
        }

        public async Task<IEnumerable<ForumHierarchicalForumDtoOut>> GetHierarchicalForumsAsync()
        {
            var apiHierarchicalForums = await _forumClient.GetHierarchicalAsync();

            return apiHierarchicalForums
                .Select(ApiHierarchicalForumDtoOutConverter.ToService);
        }

        public async Task UpdateForumAsync(int id, ForumForumDtoIn forumDtoIn)
        {
            var apiForumDtoIn = ForumForumDtoInConverter.ToExternalApi(forumDtoIn);

            await _forumClient.EditAsync(id, apiForumDtoIn);
        }

        public async Task UpdateOrderedForumsAsync(IEnumerable<ForumUpdatedOrderedForumDtoIn> updatedOrderedForumsDtoIn)
        {
            var apiUpdatedOrderedForumsDtoIn = updatedOrderedForumsDtoIn
                .Select(ForumUpdatedOrderedForumDtoInConverter.ToExternalApi);

            await _forumClient.EditOrderedAsync(apiUpdatedOrderedForumsDtoIn);
        }

        public async Task DeleteForumAsync(int id)
        {
            await _forumClient.DeleteAsync(id);
        }

        public async Task<bool> ValidateForumAsync(ForumForumDtoIn forumDtoIn)
        {
            var apiForumDtoIn = ForumForumDtoInConverter.ToExternalApi(forumDtoIn);

            await _forumClient.ValidateAsync(apiForumDtoIn);

            return true;
        }
    }
}
