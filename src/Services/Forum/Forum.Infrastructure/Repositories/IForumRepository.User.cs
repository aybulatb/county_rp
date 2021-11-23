using CountyRP.Services.Forum.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial interface IForumRepository
    {
        /// <summary>
        /// Создать пользователя.
        /// </summary>
        Task<UserDtoOut> AddUserAsync(UserDtoIn userDtoIn);

        /// <summary>
        /// Получить данные пользователя по ID.
        /// </summary>
        Task<UserDtoOut> GetUserByIdAsync(int id);

        /// <summary>
        /// Получить данные пользователя по логину.
        /// </summary>
        Task<UserDtoOut> GetUserByLoginAsync(string login);

        /// <summary>
        /// Получить отфильтрованный список пользователей.
        /// </summary>
        Task<PagedFilterResult<UserDtoOut>> GetUsersByFilterAsync(UserFilterDtoIn filterDtoIn);

        /// <summary>
        /// Изменить данные пользователя по ID.
        /// </summary>
        Task UpdateUserAsync(int id, UserDtoOut userDtoOut);

        /// <summary>
        /// Удалить пользователя по ID.
        /// </summary>
        Task DeleteUserAsync(int id);
    }
}
