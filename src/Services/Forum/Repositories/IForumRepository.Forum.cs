using CountyRP.Services.Forum.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
{
    public partial interface IForumRepository
    {
        Task<ForumDtoOut> CreateForumAsync(ForumDtoIn forumDtoIn);

        Task<IEnumerable<ForumDtoOut>> GetForumsAsync();

        Task<ForumDtoOut> GetForumByIdAsync(int id);

        Task<PagedFilterResult<ForumDtoOut>> GetForumsByFilterAsync(ForumFilterDtoIn forumFilterDtoIn);

        Task<ForumDtoOut> UpdateForumAsync(ForumDtoOut forumDtoOut);

        Task DeleteForumAsync(int id);
    }
}