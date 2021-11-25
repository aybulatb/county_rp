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

        public async Task<IEnumerable<HierarchicalForumDtoOut>> GetHierarchicalForumsAsync()
        {
            var forums = await _forumDbContext
                .Forums
                .AsNoTracking()
                .Select(forum =>
                    new HierarchicalForumDtoOut
                    {
                        Id = forum.Id,
                        Name = forum.Name,
                        ParentId = forum.ParentId,
                        Order =  forum.Order,
                        ChildForums = new List<HierarchicalForumDtoOut>()
                    }
                )
                .OrderBy(forum => forum.Order)
                .ToListAsync();

            foreach (var forum in forums)
            {
                foreach (var childForum in forums)
                {
                    if (childForum.ParentId == forum.Id)
                    {
                        forum.ChildForums.Add(childForum);
                    }
                }
            }

            var parentForums = forums
                .Where(forum => forum.ParentId == 0);

            return parentForums;
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

        public async Task<PagedFilterResult<ForumDtoOut>> GetForumsByFilterAsync(ForumFilterDtoIn filter)
        {
            var query = _forumDbContext
                .Forums
                .AsNoTracking()
                .Where(forum =>
                    (filter.Ids == null || filter.Ids.Contains(forum.Id)) &&
                    (filter.ParentIds == null || filter.ParentIds.Contains(forum.ParentId))
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

            var filteredForumsDao = await query
                .ToListAsync();

            return new PagedFilterResult<ForumDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredForumsDao
                    .Select(ForumDaoConverter.ToRepository)
            );
        }

        public async Task UpdateForumAsync(ForumDtoOut forumDtoOut)
        {
            var forumDao = ForumDtoOutConverter.ToDb(forumDtoOut);

            _forumDbContext.Forums.Update(forumDao);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task UpdateForumsAsync(IEnumerable<ForumDtoOut> forumsDtoOut)
        {
            var forumsDao = forumsDtoOut
                .Select(ForumDtoOutConverter.ToDb);

            _forumDbContext.Forums.UpdateRange(forumsDao);
            await _forumDbContext.SaveChangesAsync();
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
