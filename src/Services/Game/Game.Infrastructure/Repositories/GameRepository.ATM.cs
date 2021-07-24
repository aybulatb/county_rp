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
        public async Task<AtmDtoOut> AddAtmAsync(AtmDtoIn atmDtoIn)
        {
            var atmDao = AtmDtoInConverter.ToDb(atmDtoIn);

            await _gameDbContext.Atms.AddAsync(atmDao);

            await _gameDbContext.SaveChangesAsync();

            return AtmDaoConverter.ToRepository(atmDao);
        }

        public async Task<PagedFilterResultDtoOut<AtmDtoOut>> GetAtmsByFilter(AtmFilterDtoIn filter)
        {
            var query = GetAtmsQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetAtmsQueryWithPaging(query, filter);

            var filteredAtms = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<AtmDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredAtms
                    .Select(AtmDaoConverter.ToRepository)
                );
        }

        public async Task<AtmDtoOut> UpdateAtmAsync(AtmDtoOut atmDtoOut)
        {
            var existedAtmDao = await _gameDbContext
                .Atms
                .AsNoTracking()
                .FirstAsync(atm => atm.Id == atmDtoOut.Id);

            var editedAtmDao = AtmDtoOutConverter.ToDb(
                source: atmDtoOut
            );

            var atmDao = _gameDbContext.Atms.Update(editedAtmDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return AtmDaoConverter.ToRepository(atmDao);
        }

        public async Task DeleteAtmByFilter(AtmFilterDtoIn filter)
        {
            var query = GetAtmsQuery(filter)
                .AsNoTracking();

            query = GetAtmsQueryWithPaging(query, filter);

            _gameDbContext
                .Atms
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<AtmDao> GetAtmsQuery(AtmFilterDtoIn filter)
        {
            return _gameDbContext
               .Atms
               .Where(
                   atm =>
                       (filter.Ids == null || filter.Ids.Contains(atm.Id)) &&
                       (filter.BusinessIds == null || filter.BusinessIds.Contains(atm.BusinessId.Value))
               )
               .OrderBy(atm => atm.Id);
        }

        private IQueryable<AtmDao> GetAtmsQueryWithPaging(IQueryable<AtmDao> query, AtmFilterDtoIn filter)
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
