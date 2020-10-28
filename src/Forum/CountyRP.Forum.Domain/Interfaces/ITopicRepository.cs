using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.Domain.Interfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetByForumId(int forumId);
        Task<Topic> CreateTopic(Topic topic);
        Task<Topic> Edit(Topic topic);
        Task Delete(int id);
    }
}
