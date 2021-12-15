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
        public async Task<GarageDtoOut> AddGarageAsync(GarageDtoIn garageDtoIn)
        {
            var garageDao = GarageDtoInConverter.ToDb(garageDtoIn);

            await _gameDbContext.Garages.AddAsync(garageDao);

            await _gameDbContext.SaveChangesAsync();

            return GarageDaoConverter.ToRepository(garageDao);
        }

        public async Task<PagedFilterResultDtoOut<GarageDtoOut>> GetGaragesByFilter(GarageFilterDtoIn filter)
        {
            var query = GetGaragesQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetGaragesQueryWithPaging(query, filter);

            var filteredGarages = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<GarageDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredGarages
                    .Select(GarageDaoConverter.ToRepository)
                );
        }

        public async Task<GarageDtoOut> UpdateGarageAsync(GarageDtoOut garageDtoOut)
        {
            var existedGarageDao = await _gameDbContext
                .Garages
                .AsNoTracking()
                .FirstAsync(garage => garage.Id == garageDtoOut.Id);

            var editedGarageDao = GarageDtoOutConverter.ToDb(
                source: garageDtoOut
            );

            var garageDao = _gameDbContext.Garages.Update(editedGarageDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return GarageDaoConverter.ToRepository(garageDao);
        }

        public async Task DeleteGarageByFilter(GarageFilterDtoIn filter)
        {
            var query = GetGaragesQuery(filter)
                .AsNoTracking();

            query = GetGaragesQueryWithPaging(query, filter);

            _gameDbContext
                .Garages
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<GarageDao> GetGaragesQuery(GarageFilterDtoIn filter)
        {
            return _gameDbContext
               .Garages
               .Where(
                   garage =>
                       (filter.Ids == null || filter.Ids.Contains(garage.Id))
               )
               .OrderBy(garage => garage.Id);
        }

        private IQueryable<GarageDao> GetGaragesQueryWithPaging(IQueryable<GarageDao> query, GarageFilterDtoIn filter)
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
