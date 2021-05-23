using CountyRP.Services.Forum.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
{
    public partial interface IForumRepository
    {
        /// <summary>
        /// Создать предупреждение
        /// </summary>
        Task<WarningDtoOut> CreateWarningAsync(WarningDtoIn warningDtoIn);

        /// <summary>
        /// Получить отфильтрованный список предупреждений
        /// </summary>
        Task<PagedFilterResult<WarningDtoOut>> GetWarningsByFilterAsync(WarningFilterDtoIn filterDtoIn);

        /// <summary>
        /// Удалить предупреждение по ID
        /// </summary>
        Task DeleteWarningAsync(int id);

        /// <summary>
        /// Удалить все предупреждения у игрока под ID userId
        /// </summary>
        Task DeleteWarningsOnUserByIdAsync(int userId);
    }
}
