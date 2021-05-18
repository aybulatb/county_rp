using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
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
                .Where(
                    moderator =>
                        moderatorFilterDtoIn.EntityId.Equals(moderator.EntityId) &&
                        moderatorFilterDtoIn.EntityType.Equals(moderator.EntityType) &&
                        moderatorFilterDtoIn.ForumId.Equals(moderator.ForumId)
                )
                .AsQueryable();

            var allCount = await moderatorsQuery.CountAsync();
            var maxPages = (allCount % moderatorFilterDtoIn.Count == 0)
                ? allCount / moderatorFilterDtoIn.Count
                : allCount / moderatorFilterDtoIn.Count + 1;

            var filteredModeratorsDao = await moderatorsQuery
                .Skip(moderatorFilterDtoIn.Count * (moderatorFilterDtoIn.Page - 1))
                .Take(moderatorFilterDtoIn.Count)
                .ToListAsync();

            return new PagedFilterResult<ModeratorDtoOut>(
                allCount: allCount,
                page: moderatorFilterDtoIn.Page,
                maxPages: maxPages,
                items: filteredModeratorsDao
                    .Select(ModeratorDaoConverter.ToRepository)
            );
        }

        public async Task<ModeratorDtoOut> UpdateModeratorAsync(ModeratorDtoOut moderatorDtoOut)
        {
            var moderatorDao = ModeratorDtoOutConverter.ToDb(moderatorDtoOut);

            var updatedModeratorDao = _forumDbContext.Moderators.Update(moderatorDao)?.Entity;
            await _forumDbContext.SaveChangesAsync();

            return (updatedModeratorDao != null)
                ? ModeratorDaoConverter.ToRepository(updatedModeratorDao)
                : null;
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
