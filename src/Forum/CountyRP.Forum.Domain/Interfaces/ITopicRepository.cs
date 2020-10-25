using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface ITopicRepository
    {
        // получение всех топиков
        IEnumerable<Topic> GetById(int forumId);
        // создание топика
        Task CreateTopic(Topic topic);
        // редактирование топика
        Task Edit(int topicId);
    }
}
