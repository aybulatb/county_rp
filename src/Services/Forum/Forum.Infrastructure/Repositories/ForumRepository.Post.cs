using CountyRP.Services.Forum.Infrastructure.Converters;
using CountyRP.Services.Forum.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial class ForumRepository
    {
        public async Task<PostDtoOut> CreatePostAsync(PostDtoIn postDtoIn)
        {
            var postDao = PostDtoInConverter.ToDb(postDtoIn);

            await _forumDbContext.Posts.AddAsync(postDao);
            await _forumDbContext.SaveChangesAsync();

            return PostDaoConverter.ToRepository(postDao);
        }

        public async Task<PostDtoOut> GetPostByIdAsync(int id)
        {
            var postDao = await _forumDbContext
                .Posts
                .AsNoTracking()
                .FirstOrDefaultAsync(post => post.Id.Equals(id));

            return (postDao != null)
                ? PostDaoConverter.ToRepository(postDao)
                : null;
        }

        public async Task<PagedFilterResult<PostDtoOut>> GetPostByFilterAsync(PostFilterDtoIn filter)
        {
            var query = _forumDbContext
                .Posts
                .AsNoTracking()
                .Where(
                    post =>
                        (filter.Text == null || post.Text.Contains(filter.Text)) &&
                        filter.UserId.Equals(post.UserId) &&
                        filter.CreationDateTime.EqualsExact(post.CreationDateTime) &&
                        filter.EditionDateTime.EqualsExact(post.EditionDateTime)
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

            var filteredPostsDao = await query
                .OrderBy(post => post.CreationDateTime)
                .ToListAsync();

            return new PagedFilterResult<PostDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredPostsDao
                    .Select(PostDaoConverter.ToRepository)
            );
        }

        public async Task UpdatePostAsync(PostDtoOut postDtoOut)
        {
            var postDao = PostDtoOutConverter.ToDb(postDtoOut);

            _forumDbContext.Posts.Update(postDao);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task DeletePostByIdAsync(int id)
        {
            var post = await _forumDbContext
                .Posts
                .FirstAsync(p => p.Id.Equals(id));

            _forumDbContext.Posts.Remove(post);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task DeletePostsOnTopicByIdsAsync(IEnumerable<int> topicIds)
        {
            var affectedPosts = _forumDbContext
                .Posts
                .Where(p => topicIds.Contains(p.TopicId));

            _forumDbContext.Posts.RemoveRange(affectedPosts);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
