using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Repositories
{
    public partial class ForumRepository
    {
        public async Task<WarningDtoOut> CreateWarningAsync(WarningDtoIn warningDtoIn)
        {
            var warningDao = WarningDtoInConverter.ToDb(warningDtoIn);

            await _forumDbContext.Warnings.AddAsync(warningDao);
            await _forumDbContext.SaveChangesAsync();

            return WarningDaoConverter.ToRepository(warningDao);
        }

        public async Task<PagedFilterResult<WarningDtoOut>> GetWarningsByFilterAsync(WarningFilterDtoIn warningFilterDtoIn)
        {
            var warningsQuery = _forumDbContext
                .Warnings
                .AsNoTracking()
                .Where(
                    warning => warning.UserId.Equals(warningFilterDtoIn.UserId)
                )
                .AsQueryable();

            var allCount = await warningsQuery.CountAsync();
            var maxPages = (allCount % warningFilterDtoIn.Count == 0)
                ? allCount / warningFilterDtoIn.Count
                : allCount / warningFilterDtoIn.Count + 1;

            var filteredWarningsDao = await warningsQuery
                .OrderByDescending(warning => warning.DateTime)
                .Skip(warningFilterDtoIn.Count * (warningFilterDtoIn.Page - 1))
                .Take(warningFilterDtoIn.Count)
                .ToListAsync();

            return new PagedFilterResult<WarningDtoOut>(
                allCount: allCount,
                page: warningFilterDtoIn.Page,
                maxPages: maxPages,
                items: filteredWarningsDao
                    .Select(WarningDaoConverter.ToRepository)
            );
        }

        public async Task DeleteWarningAsync(int id)
        {
            var warning = await _forumDbContext
                .Warnings
                .FirstAsync(w => w.Id.Equals(id));

            _forumDbContext.Warnings.Remove(warning);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task DeleteWarningsOnUserByIdAsync(int userId)
        {
            var affectedWarnings = _forumDbContext
                .Warnings
                .Select(warning => warning)
                .Where(w => w.UserId == userId)
                .ToArray();

            _forumDbContext.Warnings.RemoveRange(affectedWarnings);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
