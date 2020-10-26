using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface ITopicRepository
    {
        // получение всех топиков
        Task<IEnumerable<Topic>> GetByForumId(int forumId);
        // создание топика
        Task<Topic> CreateTopic(Topic topic);
        // редактирование топика
        Task<Topic> Edit(int topicId);
    }
}
