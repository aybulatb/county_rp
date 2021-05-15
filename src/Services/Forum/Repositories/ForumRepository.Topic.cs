using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
{
    public partial class ForumRepository
    {
        public async Task<TopicDtoOut> CreateTopicAsync(TopicDtoIn topicDtoIn)
        {
            var topicDao = TopicDtoInConverter.ToDb(topicDtoIn);

            await _forumDbContext.Topics.AddAsync(topicDao);
            await _forumDbContext.SaveChangesAsync();

            return TopicDaoConverter.ToRepository(topicDao);
        }

        public async Task<TopicDtoOut> GetTopicByIdAsync(int id)
        {
            var topicDao = await _forumDbContext
                .Topics
                .AsNoTracking()
                .FirstOrDefaultAsync(topic => topic.Id == id);

            return (topicDao != null)
                ? TopicDaoConverter.ToRepository(topicDao)
                : null;
        }

        public async Task<PagedFilterResult<TopicDtoOut>> GetTopicByFilterAsync(TopicFilterDtoIn topicFilterDtoIn)
        {
            var topicsQuery = _forumDbContext
                .Topics
                .Where(
                    topic => topic.ForumId.Equals(topicFilterDtoIn.ForumId)
                )
                .AsQueryable();

            var allCount = await topicsQuery.CountAsync();
            var maxPages = (allCount % topicFilterDtoIn.Count == 0)
                ? allCount / topicFilterDtoIn.Count
                : allCount / topicFilterDtoIn.Count + 1;

            var filteredTopicsDao = await topicsQuery
                .Skip(topicFilterDtoIn.Count * (topicFilterDtoIn.Page - 1))
                .Take(topicFilterDtoIn.Count)
                .ToListAsync();

            return new PagedFilterResult<TopicDtoOut>(
                allCount: allCount,
                page: topicFilterDtoIn.Page,
                maxPages: maxPages,
                items: filteredTopicsDao
                    .Select(TopicDaoConverter.ToRepository)
            );
        }

        public async Task<TopicDtoOut> UpdateTopicAsync(TopicDtoOut topicDtoOut)
        {
            var topicDao = TopicDtoOutConverter.ToDb(topicDtoOut);

            var updatedTopicDao = _forumDbContext.Topics.Update(topicDao)?.Entity;
            await _forumDbContext.SaveChangesAsync();

            return (updatedTopicDao != null)
                ? TopicDaoConverter.ToRepository(updatedTopicDao)
                : null;
        }

        public async Task DeleteTopicByIdAsync(int id)
        {
            var topic = await _forumDbContext
                .Topics
                .FirstAsync(t => t.Id.Equals(id));

            _forumDbContext.Topics.Remove(topic);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task DeleteTopicsOnForumByIdAsync(int forumId)
        {
            var affectedTopics = _forumDbContext
                .Topics
                .Select(topic => topic)
                .Where(t => t.ForumId == forumId)
                .ToArray();

            _forumDbContext.Topics.RemoveRange(affectedTopics);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
