using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services.Interfaces
{
    public interface ITopicService
    {
        Task<IEnumerable<Topic>> GetTopicsByForumId(int id);
        Task<IEnumerable<TopicFilterViewModel>> FilterByPage(int forumId, int page);
        Task<Topic> CreateTopicAndMessage(TopicCreateViewModel topicModel);
        Task<Topic> Edit(int id, Topic topic);
        Task Delete(int id);
    }
}
