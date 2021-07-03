using CountyRP.Services.Site.Infrastructure.Converters;
using CountyRP.Services.Site.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Infrastructure.Repositories
{
    public partial class SiteRepository
    {
        public async Task<BanDtoOut> AddBanAsync(BanDtoIn banDtoIn)
        {
            var banDao = BanDtoInConverter.ToDb(banDtoIn);

            await _siteDbContext.Bans.AddAsync(banDao);
            await _siteDbContext.SaveChangesAsync();

            return BanDaoConverter.ToRepository(banDao);
        }

        public async Task<BanDtoOut> GetBanAsync(int id)
        {
            var banDao = await _siteDbContext
                .Bans
                .AsNoTracking()
                .FirstOrDefaultAsync(ban => ban.Id == id);

            return (banDao != null)
                ? BanDaoConverter.ToRepository(banDao)
                : null;
        }

        public async Task<BanDtoOut> GetBanByUserIdAsync(int userId)
        {
            var banDao = await _siteDbContext
                .Bans
                .AsNoTracking()
                .FirstOrDefaultAsync(ban => ban.UserId == userId);

            return (banDao != null)
                ? BanDaoConverter.ToRepository(banDao)
                : null;
        }

        public async Task<BanDtoOut> UpdateBanAsync(BanDtoOut banDtoOut)
        {
            var banDao = BanDtoOutConverter.ToDb(banDtoOut);

            var updatedBanDao = _siteDbContext.Bans.Update(banDao)?.Entity;
            await _siteDbContext.SaveChangesAsync();

            return (updatedBanDao != null)
                ? BanDaoConverter.ToRepository(updatedBanDao)
                : null;
        }

        public async Task<PagedFilterResult<BanDtoOut>> GetBansByFilterAsync(BanFilterDtoIn filter)
        {
            var bansQuery = _siteDbContext
                .Bans
                .AsNoTracking()
                .Where(
                    ban =>
                        (filter.StartDateTime == null || ban.StartDateTime >= filter.StartDateTime) &&
                        (filter.FinishDateTime == null || filter.FinishDateTime <= filter.FinishDateTime)
                )
                .AsQueryable();

            var allCount = await bansQuery.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            bansQuery = bansQuery
                .OrderBy(ban => ban.Id);

            if (filter.Count.HasValue && filter.Page.HasValue && filter.Count.Value > 0 && filter.Page.Value > 0)
            {
                bansQuery = bansQuery
                    .Skip(filter.Count.Value * (filter.Page.Value - 1))
                    .Take(filter.Count.Value);
            }

            var filteredBansDao = await bansQuery
                .ToListAsync();

            return new PagedFilterResult<BanDtoOut>(
                allCount: allCount,
                page: filter.Page.HasValue
                    ? filter.Page.Value
                    : 1,
                maxPages: maxPages,
                items: filteredBansDao
                    .Select(BanDaoConverter.ToRepository)
            );
        }

        public async Task DeleteBanAsync(int id)
        {
            var ban = await _siteDbContext
                .Bans
                .FirstAsync(ban => ban.Id == id);

            _siteDbContext.Bans.Remove(ban);
            await _siteDbContext.SaveChangesAsync();
        }
    }
}
