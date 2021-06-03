using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
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

        public async Task<PagedFilterResult<PostDtoOut>> GetPostByFilterAsync(PostFilterDtoIn postFilterDtoIn)
        {
            var postsQuery = _forumDbContext
                .Posts
                .AsNoTracking()
                .Where(
                    post =>
                        (postFilterDtoIn.Text == null || post.Text.Contains(postFilterDtoIn.Text)) &&
                        postFilterDtoIn.UserId.Equals(post.UserId) &&
                        postFilterDtoIn.CreationDateTime.EqualsExact(post.CreationDateTime) &&
                        postFilterDtoIn.EditionDateTime.EqualsExact(post.EditionDateTime)
                )
                .AsQueryable();

            var allCount = await postsQuery.CountAsync();
            var maxPages = (allCount % postFilterDtoIn.Count == 0)
                ? allCount / postFilterDtoIn.Count
                : allCount / postFilterDtoIn.Count + 1;

            var filteredPostsDao = await postsQuery
                .Skip(postFilterDtoIn.Count * (postFilterDtoIn.Page - 1))
                .Take(postFilterDtoIn.Count)
                .ToListAsync();

            return new PagedFilterResult<PostDtoOut>(
                allCount: allCount,
                page: postFilterDtoIn.Page,
                maxPages: maxPages,
                items: filteredPostsDao
                    .Select(PostDaoConverter.ToRepository)
            );
        }

        public async Task<PostDtoOut> UpdatePostAsync(PostDtoOut postDtoOut)
        {
            var postDao = PostDtoOutConverter.ToDb(postDtoOut);

            var updatedPostDao = _forumDbContext.Posts.Update(postDao)?.Entity;
            await _forumDbContext.SaveChangesAsync();

            return (updatedPostDao != null)
                ? PostDaoConverter.ToRepository(updatedPostDao)
                : null;
        }

        public async Task DeletePostByIdAsync(int id)
        {
            var post = await _forumDbContext
                .Posts
                .FirstAsync(p => p.Id.Equals(id));
            
            _forumDbContext.Posts.Remove(post);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task DeletePostsOnTopicByIdAsync(int topicId)
        {
            var affectedPosts = _forumDbContext
                .Posts
                .Select(post => post)
                .Where(p => p.TopicId == topicId)
                .ToArray();

            _forumDbContext.Posts.RemoveRange(affectedPosts);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
