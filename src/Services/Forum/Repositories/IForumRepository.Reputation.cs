using CountyRP.Services.Forum.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
{
    public partial interface IForumRepository
    {
        /// <summary>
        /// Создать изменение репутации.
        /// </summary>
        Task<ReputationDtoOut> CreateReputationAsync(ReputationDtoIn reputationDtoIn);

        /// <summary>
        /// Получить отфильтрованный список изменений репутации.
        /// </summary>
        Task<PagedFilterResult<ReputationDtoOut>> GetReputationsByFilterAsync(ReputationFilterDtoIn filterDtoIn);

        /// <summary>
        /// Удалить изменение репутации по ID
        /// </summary>
        Task DeleteReputationAsync(int id);

        /// <summary>
        /// Удалить все изменений репутаций у игрока под ID userId
        /// </summary>
        Task DeleteReputationsOnUserByIdAsync(int userId);
    }
}
