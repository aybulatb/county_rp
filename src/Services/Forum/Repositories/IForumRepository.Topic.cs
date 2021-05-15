using CountyRP.Services.Forum.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
{
    public partial interface IForumRepository
    {
        /// <summary>
        /// Создать тему
        /// </summary>
        /// <param name="topicDtoIn"></param>
        /// <returns></returns>
        Task<TopicDtoOut> CreateTopicAsync(TopicDtoIn topicDtoIn);

        /// <summary>
        /// Получить данные темы по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TopicDtoOut> GetTopicByIdAsync(int id);

        /// <summary>
        /// Получить отфильтрованный список тем
        /// </summary>
        /// <param name="topicFilterDtoIn"></param>
        /// <returns></returns>
        Task<PagedFilterResult<TopicDtoOut>> GetTopicByFilterAsync(TopicFilterDtoIn topicFilterDtoIn);

        /// <summary>
        /// Изменить данные темы по ID
        /// </summary>
        /// <param name="topicDtoIn"></param>
        /// <returns></returns>
        Task<TopicDtoOut> UpdateTopicAsync(TopicDtoOut topicDtoOut);

        /// <summary>
        /// Удалить тему по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteTopicByIdAsync(int id);

        /// <summary>
        /// Удалить все темы на форуме с ID forumId
        /// </summary>
        /// <param name="forumId"></param>
        /// <returns></returns>
        Task DeleteTopicsOnForumByIdAsync(int forumId);
    }
}
