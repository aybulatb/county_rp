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
        public async Task<ForumDtoOut> CreateForumAsync(ForumDtoIn forumDtoIn)
        {
            var forumDao = ForumDtoInConverter.ToDb(forumDtoIn);

            await _forumDbContext.Forums.AddAsync(forumDao);
            await _forumDbContext.SaveChangesAsync();

            return ForumDaoConverter.ToRepository(forumDao);
        }

        public async Task<IEnumerable<ForumDtoOut>> GetForumsAsync()
        {
            var forumsDao = await _forumDbContext
                .Forums
                .AsNoTracking()
                .ToArrayAsync();

            return forumsDao.Select(ForumDaoConverter.ToRepository);
        }

        public async Task<ForumDtoOut> GetForumByIdAsync(int id)
        {
            var forumDao = await _forumDbContext
                .Forums
                .AsNoTracking()
                .FirstOrDefaultAsync(forums => forums.Id.Equals(id));

            return (forumDao != null)
                ? ForumDaoConverter.ToRepository(forumDao)
                : null;
        }

        public async Task<PagedFilterResult<ForumDtoOut>> GetForumsByFilterAsync(ForumFilterDtoIn filterDtoIn)
        {
            var forumsQuery = _forumDbContext
                .Forums
                .AsNoTracking()
                .Where(
                    forum => forum.ParentId.Equals(filterDtoIn.ParentId)
                )
                .AsQueryable();

            var allCount = await forumsQuery.CountAsync();
            var maxPages = (allCount % filterDtoIn.Count == 0)
                ? allCount / filterDtoIn.Count
                : allCount / filterDtoIn.Count + 1;

            var filteredForumsDao = await forumsQuery
                .OrderBy(forum => forum.Id)
                .Skip(filterDtoIn.Count * (filterDtoIn.Page - 1))
                .Take(filterDtoIn.Count)
                .ToListAsync();

            return new PagedFilterResult<ForumDtoOut>(
                allCount: allCount,
                page: filterDtoIn.Page,
                maxPages: maxPages,
                items: filteredForumsDao
                    .Select(ForumDaoConverter.ToRepository)
            );
        }

        public async Task<ForumDtoOut> UpdateForumAsync(ForumDtoOut forumDtoOut)
        {
            var forumDao = ForumDtoOutConverter.ToDb(forumDtoOut);

            var updatedForumDao = _forumDbContext.Forums.Update(forumDao)?.Entity;
            await _forumDbContext.SaveChangesAsync();

            return (updatedForumDao != null)
                ? ForumDaoConverter.ToRepository(updatedForumDao)
                : null;
        }

        public async Task DeleteForumAsync(int id)
        {
            var forum = await _forumDbContext
                .Forums
                .FirstAsync(f => f.Id.Equals(id));

            _forumDbContext.Forums.Remove(forum);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
