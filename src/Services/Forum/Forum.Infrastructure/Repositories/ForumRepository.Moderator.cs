using CountyRP.Services.Forum.Infrastructure.Converters;
using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial class ForumRepository
    {
        public async Task<ModeratorDtoOut> AddModeratorAsync(ModeratorDtoIn moderatorDtoIn)
        {
            var moderatorDao = ModeratorDtoInConverter.ToDb(moderatorDtoIn);

            await _forumDbContext.Moderators.AddAsync(moderatorDao);
            await _forumDbContext.SaveChangesAsync();

            return ModeratorDaoConverter.ToRepository(moderatorDao);
        }

        public async Task AddModeratorsAsync(IEnumerable<ModeratorDtoIn> moderatorsDtoIn)
        {
            var moderatorsDao = moderatorsDtoIn
                .Select(ModeratorDtoInConverter.ToDb);

            _forumDbContext.Moderators.AddRange(moderatorsDao);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task<ModeratorDtoOut> GetModeratorByIdAsync(int id)
        {
            var moderatorDao = await _forumDbContext
                .Moderators
                .AsNoTracking()
                .FirstOrDefaultAsync(moderator => moderator.Id.Equals(id));

            return (moderatorDao != null)
                ? ModeratorDaoConverter.ToRepository(moderatorDao)
                : null;
        }

        public async Task<PagedFilterResult<ModeratorDtoOut>> GetModeratorByFilterAsync(ModeratorFilterDtoIn filter)
        {
            var query = GetModeratorsQuery(filter);

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetModeratorsQueryWithPaging(query, filter);

            var filteredModeratorsDao = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResult<ModeratorDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredModeratorsDao
                    .Select(ModeratorDaoConverter.ToRepository)
            );
        }

        public async Task UpdateModeratorAsync(ModeratorDtoOut moderatorDtoOut)
        {
            var moderatorDao = ModeratorDtoOutConverter.ToDb(moderatorDtoOut);

            _forumDbContext.Moderators.Update(moderatorDao);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task UpdateModeratorsAsync(IEnumerable<ModeratorDtoOut> moderatorsDtoOut)
        {
            var moderatorsDao = moderatorsDtoOut
                .Select(ModeratorDtoOutConverter.ToDb);

            _forumDbContext.Moderators.UpdateRange(moderatorsDao);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task DeleteModeratorAsync(int id)
        {
            var moderator = await _forumDbContext
                .Moderators
                .FirstAsync(t => t.Id.Equals(id));

            _forumDbContext.Moderators.Remove(moderator);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task DeleteModeratorsByFilterAsync(ModeratorFilterDtoIn filter)
        {
            var query = GetModeratorsQuery(filter);

            query = GetModeratorsQueryWithPaging(query, filter);

            var moderatorsForDeleting = query;

            _forumDbContext.Moderators.RemoveRange(moderatorsForDeleting);
            await _forumDbContext.SaveChangesAsync();
        }

        private IQueryable<ModeratorDao> GetModeratorsQuery(ModeratorFilterDtoIn filter)
        {
            return _forumDbContext
                .Moderators
                .AsNoTracking()
                .Where(
                    moderator =>
                        (filter.EntityId == null || filter.EntityId.Equals(moderator.EntityId)) &&
                        (filter.EntityType == null || filter.EntityType.Equals(moderator.EntityType)) &&
                        (filter.ForumId == null || filter.ForumId.Equals(moderator.ForumId))
                );
        }

        private IQueryable<ModeratorDao> GetModeratorsQueryWithPaging(IQueryable<ModeratorDao> query, ModeratorFilterDtoIn filter)
        {
            if (filter.Page.HasValue && filter.Count.HasValue && filter.Count.Value > 0 && filter.Page.Value > 0)
            {
                query = query
                   .Skip((filter.Page.Value - 1) * filter.Count.Value)
                   .Take(filter.Count.Value);
            }

            return query;
        }
    }
}
