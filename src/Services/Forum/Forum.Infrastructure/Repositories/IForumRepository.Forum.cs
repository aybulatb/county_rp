using CountyRP.Services.Forum.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial interface IForumRepository
    {
        /// <summary>
        /// Создать форум
        /// </summary>
        Task<ForumDtoOut> CreateForumAsync(ForumDtoIn forumDtoIn);

        /// <summary>
        /// Получить все форумы
        /// </summary>
        Task<IEnumerable<ForumDtoOut>> GetForumsAsync();

        /// <summary>
        /// Получить данные форума по ID
        /// </summary>
        Task<ForumDtoOut> GetForumByIdAsync(int id);

        /// <summary>
        /// Получить отфильтрованный список форумов
        /// </summary>
        Task<PagedFilterResult<ForumDtoOut>> GetForumsByFilterAsync(ForumFilterDtoIn forumFilterDtoIn);

        /// <summary>
        /// Изменить данные форума
        /// </summary>
        Task<ForumDtoOut> UpdateForumAsync(ForumDtoOut forumDtoOut);

        /// <summary>
        /// Удалить форум по ID
        /// </summary>
        Task DeleteForumAsync(int id);
    }
}
