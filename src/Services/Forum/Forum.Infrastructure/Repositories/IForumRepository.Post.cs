using CountyRP.Services.Forum.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial interface IForumRepository
    {
        /// <summary>
        /// Создать сообщение
        /// </summary>
        Task<PostDtoOut> CreatePostAsync(PostDtoIn postDtoIn);

        /// <summary>
        /// Получить данные сообщения по ID
        /// </summary>
        Task<PostDtoOut> GetPostByIdAsync(int id);

        /// <summary>
        /// Получить отфильтрованный список сообщений
        /// </summary>
        Task<PagedFilterResult<PostDtoOut>> GetPostByFilterAsync(PostFilterDtoIn postFilterDtoIn);

        /// <summary>
        /// Изменить данные сообщения по ID
        /// </summary>
        Task UpdatePostAsync(PostDtoOut postDtoOut);

        /// <summary>
        /// Удалить сообщение по ID
        /// </summary>
        Task DeletePostByIdAsync(int id);

        /// <summary>
        /// Удалить все сообщения в теме с ID topicId
        /// </summary>
        Task DeletePostsOnTopicByIdAsync(int topicId);
    }
}
