using CountyRP.Services.Forum.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial interface IForumRepository
    {
        /// <summary>
        /// Создать модератора
        /// </summary>
        /// <param name="moderatorDtoIn"></param>
        /// <returns></returns>
        Task<ModeratorDtoOut> AddModeratorAsync(ModeratorDtoIn moderatorDtoIn);

        /// <summary>
        /// Получить данные модератора по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ModeratorDtoOut> GetModeratorByIdAsync(int id);

        /// <summary>
        /// Получить отфильтрованный список модераторов
        /// </summary>
        /// <param name="moderatorFilterDtoIn"></param>
        /// <returns></returns>
        Task<PagedFilterResult<ModeratorDtoOut>> GetModeratorByFilterAsync(ModeratorFilterDtoIn moderatorFilterDtoIn);

        /// <summary>
        /// Изменить данные модератора по ID
        /// </summary>
        /// <param name="moderatorDtoOut"></param>
        /// <returns></returns>
        Task<ModeratorDtoOut> UpdateModeratorAsync(ModeratorDtoOut moderatorDtoOut);

        /// <summary>
        /// Удалить модератора по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteModeratorByIdAsync(int id);
    }
}
