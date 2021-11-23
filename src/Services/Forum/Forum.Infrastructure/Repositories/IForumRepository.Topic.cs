using CountyRP.Services.Forum.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial interface IForumRepository
    {
        /// <summary>
        /// Создать тему
        /// </summary>
        Task<TopicDtoOut> CreateTopicAsync(TopicDtoIn topicDtoIn);

        /// <summary>
        /// Получить данные темы по ID
        /// </summary>
        Task<TopicDtoOut> GetTopicByIdAsync(int id);

        /// <summary>
        /// Получить отфильтрованный список тем
        /// </summary>
        Task<PagedFilterResult<TopicDtoOut>> GetTopicByFilterAsync(TopicFilterDtoIn topicFilterDtoIn);

        /// <summary>
        /// Изменить данные темы по ID
        /// </summary>
        Task UpdateTopicAsync(TopicDtoOut topicDtoOut);

        /// <summary>
        /// Удалить тему по ID
        /// </summary>
        Task DeleteTopicByIdAsync(int id);

        /// <summary>
        /// Удалить все темы на форуме с ID forumId
        /// </summary>
        Task DeleteTopicsOnForumByIdAsync(int forumId);
    }
}
