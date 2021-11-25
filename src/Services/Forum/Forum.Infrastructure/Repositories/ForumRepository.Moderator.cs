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

        public async Task<PagedFilterResult<ModeratorDtoOut>> GetModeratorByFilterAsync(ModeratorFilterDtoIn moderatorFilterDtoIn)
        {
            var moderatorsQuery = _forumDbContext
                .Moderators
                .AsNoTracking()
                .Where(
                    moderator =>
                        (moderatorFilterDtoIn.EntityId == null || moderatorFilterDtoIn.EntityId.Equals(moderator.EntityId)) &&
                        (moderatorFilterDtoIn.EntityType == null || moderatorFilterDtoIn.EntityType.Equals(moderator.EntityType)) &&
                        (moderatorFilterDtoIn.ForumId == null || moderatorFilterDtoIn.ForumId.Equals(moderator.ForumId))
                )
                .AsQueryable();

            var allCount = await moderatorsQuery.CountAsync();
            var maxPages = (allCount % moderatorFilterDtoIn.Count == 0)
                ? allCount / moderatorFilterDtoIn.Count
                : allCount / moderatorFilterDtoIn.Count + 1;

            var filteredModeratorsDao = await moderatorsQuery
                .OrderBy(moderator => moderator.Id)
                .Skip(moderatorFilterDtoIn.Count.Value * (moderatorFilterDtoIn.Page.Value - 1))
                .Take(moderatorFilterDtoIn.Count.Value)
                .ToListAsync();

            return new PagedFilterResult<ModeratorDtoOut>(
                allCount: allCount,
                page: moderatorFilterDtoIn.Page ?? 1,
                maxPages: maxPages ?? 1,
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

        public async Task DeleteModeratorByIdAsync(int id)
        {
            var moderator = await _forumDbContext
                .Moderators
                .FirstAsync(t => t.Id.Equals(id));

            _forumDbContext.Moderators.Remove(moderator);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
