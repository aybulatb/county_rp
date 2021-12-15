using CountyRP.Services.Game.Infrastructure.Converters.Ban;
using CountyRP.Services.Game.Infrastructure.Infrastructure.Models.Ban;
using CountyRP.Services.Game.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<BanDtoOut> GetBanAsync(int id)
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
            var bansQuery = _gameDbContext
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
            var ban = await _gameDbContext
                .Bans
                .FirstAsync(ban => ban.Id == id);

            _gameDbContext.Bans.Remove(ban);
            await _gameDbContext.SaveChangesAsync();
        }
    }
}
