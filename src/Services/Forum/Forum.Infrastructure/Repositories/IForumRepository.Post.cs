using CountyRP.Services.Forum.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial interface IForumRepository
    {
        /// <summary>
        /// Создать сообщение
        /// </summary>
        /// <param name="postDtoIn"></param>
        /// <returns></returns>
        Task<PostDtoOut> CreatePostAsync(PostDtoIn postDtoIn);

        /// <summary>
        /// Получить данные сообщения по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PostDtoOut> GetPostByIdAsync(int id);

        /// <summary>
        /// Получить отфильтрованный список сообщений
        /// </summary>
        /// <param name="postFilterDtoIn"></param>
        /// <returns></returns>
        Task<PagedFilterResult<PostDtoOut>> GetPostByFilterAsync(PostFilterDtoIn postFilterDtoIn);

        /// <summary>
        /// Изменить данные сообщения по ID
        /// </summary>
        /// <param name="postDtoOut"></param>
        /// <returns></returns>
        Task<PostDtoOut> UpdatePostAsync(PostDtoOut postDtoOut);

        /// <summary>
        /// Удалить сообщение по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeletePostByIdAsync(int id);

        /// <summary>
        /// Удалить все сообщения в теме с ID topicId
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        Task DeletePostsOnTopicByIdAsync(int topicId);
    }
}
