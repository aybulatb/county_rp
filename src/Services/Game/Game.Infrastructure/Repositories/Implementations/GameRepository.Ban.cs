using CountyRP.Services.Game.Infrastructure.Converters.Ban;
using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Infrastructure.Models.Ban;
using CountyRP.Services.Game.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories.Implementations
{
    public partial class GameRepository
    {
        public async Task<BanDtoOut> AddBanAsync(BanDtoIn banDtoIn)
        {
            var banDao = BanDtoInConverter.ToDb(banDtoIn);

            await _gameDbContext.Bans.AddAsync(banDao);
            await _gameDbContext.SaveChangesAsync();

            return BanDaoConverter.ToRepository(banDao);
        }

        public async Task<BanDtoOut> GetBanOrDefaultAsync(int id)
        {
            var banDao = await _gameDbContext
                .Bans
                .AsNoTracking()
                .FirstOrDefaultAsync(ban => ban.Id == id);

            return (banDao != null)
                ? BanDaoConverter.ToRepository(banDao)
                : null;
        }

        public async Task<PagedFilterResultDtoOut<BanDtoOut>> GetBansByFilterAsync(BanFilterDtoIn filter)
        {
            var query = GetQueryWithFilter(filter);

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            if (filter.Count.HasValue && filter.Page.HasValue)
            {
                query = GetQueryWithPaging(query, filter.Count.Value, filter.Page.Value);
            }

            var filteredBansDao = await query
                .ToListAsync();

            return new PagedFilterResultDtoOut<BanDtoOut>(
                allCount: allCount,
                page: filter.Page.HasValue
                    ? filter.Page.Value
                    : 1,
                maxPages: maxPages,
                items: filteredBansDao
                    .Select(BanDaoConverter.ToRepository)
            );
        }

        public async Task UpdateBanAsync(BanDtoOut banDtoOut)
        {
            var banDao = BanDtoOutConverter.ToDb(banDtoOut);

            _gameDbContext.Bans.Update(banDao);
            await _gameDbContext.SaveChangesAsync();
        }

        public async Task DeleteBanAsync(int id)
        {
            var banDao = await _gameDbContext
                .Bans
                .FirstOrDefaultAsync(ban => ban.Id == id);

            _gameDbContext.Bans.Remove(banDao);
            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<BanDao> GetQueryWithFilter(BanFilterDtoIn filter)
        {
            var query = _gameDbContext
                .Bans
                .AsNoTracking()
                .Where(
                    ban =>
                        (filter.PlayerId == null || ban.PlayerId == filter.PlayerId) &&
                        (filter.PersonId == null || ban.PersonId == filter.PersonId) &&
                        (filter.StartDateTime == null || ban.StartDateTime >= filter.StartDateTime) &&
                        (filter.FinishDateTime == null || filter.FinishDateTime <= filter.FinishDateTime)
                )
                .OrderBy(ban => ban.Id)
                .AsQueryable();

            return query;
        }

        private IQueryable<BanDao> GetQueryWithPaging(IQueryable<BanDao> query, int count, int page)
        {
            if (count > 0 && page > 0)
            {
                query = query
                    .Skip(count * (page - 1))
                    .Take(count);
            }

            return query;
        }
    }
}
