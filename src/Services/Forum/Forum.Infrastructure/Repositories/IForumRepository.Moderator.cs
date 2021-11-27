using CountyRP.Services.Forum.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial interface IForumRepository
    {
        /// <summary>
        /// Создать модератора.
        /// </summary>
        Task<ModeratorDtoOut> AddModeratorAsync(ModeratorDtoIn moderatorDtoIn);

        /// <summary>
        /// Создать модераторов.
        /// </summary>
        Task AddModeratorsAsync(IEnumerable<ModeratorDtoIn> moderatorsDtoIn);

        /// <summary>
        /// Получить данные модератора по ID.
        /// </summary>
        Task<ModeratorDtoOut> GetModeratorByIdAsync(int id);

        /// <summary>
        /// Получить отфильтрованный список модераторов.
        /// </summary>
        Task<PagedFilterResult<ModeratorDtoOut>> GetModeratorByFilterAsync(ModeratorFilterDtoIn filter);

        /// <summary>
        /// Изменить данные модератора по ID.
        /// </summary>
        Task UpdateModeratorAsync(ModeratorDtoOut moderatorDtoOut);

        /// <summary>
        /// Изменить данные модераторов.
        /// </summary>
        Task UpdateModeratorsAsync(IEnumerable<ModeratorDtoOut> moderatorsDtoOut);

        /// <summary>
        /// Удалить модератора по ID.
        /// </summary>
        Task DeleteModeratorAsync(int id);

        /// <summary>
        /// Удалить модераторов по фильтру.
        /// </summary>
        Task DeleteModeratorsByFilterAsync(ModeratorFilterDtoIn filter);
    }
}
