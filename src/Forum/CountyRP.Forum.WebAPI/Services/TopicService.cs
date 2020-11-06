using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.WebAPI.Services.Interfaces;

namespace CountyRP.Forum.WebAPI.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<IEnumerable<Topic>> GetTopicsByForumId(int id)
        {
            var topics = await _topicRepository.GetByForumId(id);

            return topics;
        }

        public async Task<Topic> CreateTopic(Topic topic)
        {
            var createdTopic = await _topicRepository.CreateTopic(topic);

            return createdTopic;
        }

        public async Task Delete(int id)
        {
            await _topicRepository.Delete(id);
        }

        public async Task<Topic> Edit(Topic topic)
        {
            var editedTopic = await _topicRepository.Edit(topic);

            return editedTopic;
        }
    }
}
