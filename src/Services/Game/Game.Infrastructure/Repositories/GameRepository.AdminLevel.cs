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
        public async Task<AdminLevelDtoOut> AddAdminLevelAsync(AdminLevelDtoIn adminLevelDtoIn)
        {
            var adminLevelDao = AdminLevelDtoInConverter.ToDb(adminLevelDtoIn);

            await _gameDbContext.AdminLevels.AddAsync(adminLevelDao);

            await _gameDbContext.SaveChangesAsync();

            return AdminLevelDaoConverter.ToRepository(adminLevelDao);
        }

        public async Task<PagedFilterResultDtoOut<AdminLevelDtoOut>> GetAdminLevelsByFilter(AdminLevelFilterDtoIn filter)
        {
            var query = GetAdminLevelsQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetAdminLevelsQueryWithPaging(query, filter);

            var filteredAdminLevels = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<AdminLevelDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredAdminLevels
                    .Select(AdminLevelDaoConverter.ToRepository)
                );
        }

        public async Task<AdminLevelDtoOut> UpdateAdminLevelAsync(AdminLevelDtoOut adminLevelDtoOut)
        {
            var existedAdminLevelDao = await _gameDbContext
                .AdminLevels
                .AsNoTracking()
                .FirstAsync(adminLevel => adminLevel.Id == adminLevelDtoOut.Id);

            var editedAdminLevelDao = AdminLevelDtoOutConverter.ToDb(
                source: adminLevelDtoOut
            );

            var adminLevelDao = _gameDbContext.AdminLevels.Update(editedAdminLevelDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return AdminLevelDaoConverter.ToRepository(adminLevelDao);
        }

        public async Task DeleteAdminLevelByFilter(AdminLevelFilterDtoIn filter)
        {
            var query = GetAdminLevelsQuery(filter)
                .AsNoTracking();

            query = GetAdminLevelsQueryWithPaging(query, filter);

            _gameDbContext
                .AdminLevels
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<AdminLevelDao> GetAdminLevelsQuery(AdminLevelFilterDtoIn filter)
        {
            return _gameDbContext
               .AdminLevels
               .Where(
                   adminLevel =>
                       (filter.Ids == null || filter.Ids.Contains(adminLevel.Id)) &&
                       (filter.Names == null || filter.Names.Contains(adminLevel.Name)) &&
                       (filter.NameLike == null || adminLevel.Name.Contains(filter.NameLike))
               )
               .OrderBy(adminLevel => adminLevel.Id);
        }

        private IQueryable<AdminLevelDao> GetAdminLevelsQueryWithPaging(IQueryable<AdminLevelDao> query, AdminLevelFilterDtoIn filter)
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
