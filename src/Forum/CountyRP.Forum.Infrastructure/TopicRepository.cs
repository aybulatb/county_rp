using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CountyRP.Forum.Domain;
using CountyRP.Forum.Domain.Exceptions;
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

        public IEnumerable<Topic> GetById(int id)
        {
            try
            {
                var topics = _topicContext.Topics.Where(t => t.ForumId == id).ToList();

                return topics;
            }
            catch (Extra.ApiException ex)
            {
                throw new ForumException(ex.StatusCode, ex.Message);
            }
        }

        public async Task CreateTopic(Topic topic)
        {
            try
            {
                _topicContext.Topics.Add(topic);

                await _topicContext.SaveChangesAsync();
            }
            catch (Extra.ApiException ex)
            {
                throw new ForumException(ex.StatusCode, ex.Message);
            }
        }

        public Task Edit(int topicId)
        {
            throw new NotImplementedException();
        }

    }
}
