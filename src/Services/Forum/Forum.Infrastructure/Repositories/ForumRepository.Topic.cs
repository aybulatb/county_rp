using CountyRP.Services.Forum.Infrastructure.Converters;
using CountyRP.Services.Forum.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
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
                .FirstOrDefaultAsync(topic => topic.Id.Equals(id));

            return (topicDao != null)
                ? TopicDaoConverter.ToRepository(topicDao)
                : null;
        }

        public async Task<PagedFilterResult<TopicDtoOut>> GetTopicByFilterAsync(TopicFilterDtoIn filter)
        {
            var query = _forumDbContext
                .Topics
                .AsNoTracking()
                .Where(
                    topic => topic.ForumId.Equals(filter.ForumId)
                )
                .AsQueryable();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            if (filter.Page.HasValue && filter.Count.HasValue && filter.Count.Value > 0 && filter.Page.Value > 0)
            {
                query = query
                   .Skip((filter.Page.Value - 1) * filter.Count.Value)
                   .Take(filter.Count.Value);
            }

            var filteredTopicsDao = await query
                .ToListAsync();

            return new PagedFilterResult<TopicDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredTopicsDao
                    .Select(TopicDaoConverter.ToRepository)
            );
        }

        public async Task UpdateTopicAsync(TopicDtoOut topicDtoOut)
        {
            var topicDao = TopicDtoOutConverter.ToDb(topicDtoOut);

            _forumDbContext.Topics.Update(topicDao);
            await _forumDbContext.SaveChangesAsync();
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
