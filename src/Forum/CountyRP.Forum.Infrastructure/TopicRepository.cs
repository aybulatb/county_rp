using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CountyRP.Forum.Domain;
using CountyRP.Forum.Domain.Interfaces;

namespace CountyRP.Forum.Infrastructure
{
    public class TopicRepository : ITopicRepository
    {
        private readonly TopicContext _topicContext;

        public TopicRepository(TopicContext topicContext)
        {
            _topicContext = topicContext;
        }

        public async Task<IEnumerable<Topic>> GetByForumId(int id)
        {
            var topics = _topicContext.Topics.Where(t => t.ForumId == id).ToList();

            return topics;
        }

        public async Task<Topic> CreateTopic(Topic topic)
        {
            _topicContext.Topics.Add(topic);

            await _topicContext.SaveChangesAsync();

            return topic;
        }

        public Task<Topic> Edit(int topicId)
        {
            throw new NotImplementedException();
        }

    }
}
