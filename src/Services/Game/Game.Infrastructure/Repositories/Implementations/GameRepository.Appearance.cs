using CountyRP.Services.Game.Infrastructure.Converters;
using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories.Implementations
{
    public partial class GameRepository
    {
        public async Task<AppearanceDtoOut> AddAppearanceAsync(AppearanceDtoIn appearanceDtoIn)
        {
            var appearanceDao = AppearanceDtoInConverter.ToDb(appearanceDtoIn);

            await _gameDbContext.Appearances.AddAsync(appearanceDao);

            await _gameDbContext.SaveChangesAsync();

            return AppearanceDaoConverter.ToRepository(appearanceDao);
        }

        public async Task<PagedFilterResultDtoOut<AppearanceDtoOut>> GetAppearancesByFilter(AppearanceFilterDtoIn filter)
        {
            var query = GetAppearancesQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetAppearancesQueryWithPaging(query, filter);

            var filteredAppearances = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<AppearanceDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredAppearances
                    .Select(AppearanceDaoConverter.ToRepository)
                );
        }

        public async Task<AppearanceDtoOut> UpdateAppearanceAsync(AppearanceDtoOut appearanceDtoOut)
        {
            var existedAppearanceDao = await _gameDbContext
                .Appearances
                .AsNoTracking()
                .FirstAsync(appearance => appearance.Id == appearanceDtoOut.Id);

            var editedAppearanceDao = AppearanceDtoOutConverter.ToDb(
                source: appearanceDtoOut
            );

            var appearanceDao = _gameDbContext.Appearances.Update(editedAppearanceDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return AppearanceDaoConverter.ToRepository(appearanceDao);
        }

        public async Task DeleteAppearanceByFilter(AppearanceFilterDtoIn filter)
        {
            var query = GetAppearancesQuery(filter)
                .AsNoTracking();

            query = GetAppearancesQueryWithPaging(query, filter);

            _gameDbContext
                .Appearances
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<AppearanceDao> GetAppearancesQuery(AppearanceFilterDtoIn filter)
        {
            return _gameDbContext
               .Appearances
               .Where(
                   appearance =>
                       (filter.Ids == null || filter.Ids.Contains(appearance.Id))
               )
               .OrderBy(appearance => appearance.Id);
        }

        private IQueryable<AppearanceDao> GetAppearancesQueryWithPaging(IQueryable<AppearanceDao> query, AppearanceFilterDtoIn filter)
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
