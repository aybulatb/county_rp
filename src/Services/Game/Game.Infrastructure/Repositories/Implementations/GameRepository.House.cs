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
        public async Task<HouseDtoOut> AddHouseAsync(HouseDtoIn houseDtoIn)
        {
            var houseDao = HouseDtoInConverter.ToDb(houseDtoIn);

            await _gameDbContext.Houses.AddAsync(houseDao);

            await _gameDbContext.SaveChangesAsync();

            return HouseDaoConverter.ToRepository(houseDao);
        }

        public async Task<PagedFilterResultDtoOut<HouseDtoOut>> GetHousesByFilter(HouseFilterDtoIn filter)
        {
            var query = GetHousesQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetHousesQueryWithPaging(query, filter);

            var filteredHouses = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<HouseDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredHouses
                    .Select(HouseDaoConverter.ToRepository)
                );
        }

        public async Task<HouseDtoOut> UpdateHouseAsync(HouseDtoOut houseDtoOut)
        {
            var existedHouseDao = await _gameDbContext
                .Houses
                .AsNoTracking()
                .FirstAsync(house => house.Id == houseDtoOut.Id);

            var editedHouseDao = HouseDtoOutConverter.ToDb(
                source: houseDtoOut
            );

            var houseDao = _gameDbContext.Houses.Update(editedHouseDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return HouseDaoConverter.ToRepository(houseDao);
        }

        public async Task DeleteHouseByFilter(HouseFilterDtoIn filter)
        {
            var query = GetHousesQuery(filter)
                .AsNoTracking();

            query = GetHousesQueryWithPaging(query, filter);

            _gameDbContext
                .Houses
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<HouseDao> GetHousesQuery(HouseFilterDtoIn filter)
        {
            return _gameDbContext
               .Houses
               .Where(
                   house =>
                       (filter.Ids == null || filter.Ids.Contains(house.Id)) &&
                       (filter.OwnerIds == null || filter.OwnerIds.Contains(house.OwnerId.Value)) &&
                       (filter.GarageIds == null || filter.GarageIds.Contains(house.GarageId.Value))
               )
               .OrderBy(house => house.Id);
        }

        private IQueryable<HouseDao> GetHousesQueryWithPaging(IQueryable<HouseDao> query, HouseFilterDtoIn filter)
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
