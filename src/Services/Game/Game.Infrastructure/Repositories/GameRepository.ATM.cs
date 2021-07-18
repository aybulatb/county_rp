using CountyRP.Services.Game.Infrastructure.Converters;
using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial class GameRepository
    {
        public async Task<ATMDtoOut> AddATMAsync(ATMDtoIn atmDtoIn)
        {
            var atmDao = ATMDtoInConverter.ToDb(atmDtoIn);

            await _gameDbContext.ATMs.AddAsync(atmDao);

            await _gameDbContext.SaveChangesAsync();

            return ATMDaoConverter.ToRepository(atmDao);
        }

        public async Task<PagedFilterResultDtoOut<ATMDtoOut>> GetATMsByFilter(ATMFilterDtoIn filter)
        {
            var query = GetATMsQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetATMsQueryWithPaging(query, filter);

            var filteredATMs = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<ATMDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredATMs
                    .Select(ATMDaoConverter.ToRepository)
                );
        }

        public async Task<ATMDtoOut> UpdateATMAsync(ATMDtoOut atmDtoOut)
        {
            var existedATMDao = await _gameDbContext
                .ATMs
                .AsNoTracking()
                .FirstAsync(atm => atm.Id == atmDtoOut.Id);

            var editedATMDao = ATMDtoOutConverter.ToDb(
                source: atmDtoOut
            );

            var atmDao = _gameDbContext.ATMs.Update(editedATMDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return ATMDaoConverter.ToRepository(atmDao);
        }

        public async Task DeleteATMByFilter(ATMFilterDtoIn filter)
        {
            var query = GetATMsQuery(filter)
                .AsNoTracking();

            query = GetATMsQueryWithPaging(query, filter);

            _gameDbContext
                .ATMs
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<ATMDao> GetATMsQuery(ATMFilterDtoIn filter)
        {
            return _gameDbContext
               .ATMs
               .Where(
                   atm =>
                       (filter.Ids == null || filter.Ids.Contains(atm.Id)) &&
                       (filter.BusinessIds == null || filter.BusinessIds.Contains(atm.BusinessId))
               )
               .OrderBy(atm => atm.Id);
        }

        private IQueryable<ATMDao> GetATMsQueryWithPaging(IQueryable<ATMDao> query, ATMFilterDtoIn filter)
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
