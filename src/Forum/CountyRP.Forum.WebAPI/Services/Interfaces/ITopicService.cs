using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.WebAPI.Services.Interfaces
{
    public interface ITopicService
    {
        Task<IEnumerable<Topic>> GetTopicsByForumId(int id);
        Task<Topic> CreateTopic(Topic topic);
        Task<Topic> Edit(Topic topic);
        Task Delete(int id);
    }
}
