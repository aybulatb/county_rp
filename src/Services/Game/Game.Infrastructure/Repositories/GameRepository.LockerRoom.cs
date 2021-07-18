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
        public async Task<LockerRoomDtoOut> AddLockerRoomAsync(LockerRoomDtoIn lockerRoomDtoIn)
        {
            var lockerRoomDao = LockerRoomDtoInConverter.ToDb(lockerRoomDtoIn);

            await _gameDbContext.LockerRooms.AddAsync(lockerRoomDao);

            await _gameDbContext.SaveChangesAsync();

            return LockerRoomDaoConverter.ToRepository(lockerRoomDao);
        }

        public async Task<PagedFilterResultDtoOut<LockerRoomDtoOut>> GetLockerRoomsByFilter(LockerRoomFilterDtoIn filter)
        {
            var query = GetLockerRoomsQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetLockerRoomsQueryWithPaging(query, filter);

            var filteredLockerRooms = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<LockerRoomDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredLockerRooms
                    .Select(LockerRoomDaoConverter.ToRepository)
                );
        }

        public async Task<LockerRoomDtoOut> UpdateLockerRoomAsync(LockerRoomDtoOut lockerRoomDtoOut)
        {
            var existedLockerRoomDao = await _gameDbContext
                .LockerRooms
                .AsNoTracking()
                .FirstAsync(lockerRoom => lockerRoom.Id == lockerRoomDtoOut.Id);

            var editedLockerRoomDao = LockerRoomDtoOutConverter.ToDb(
                source: lockerRoomDtoOut
            );

            var lockerRoomDao = _gameDbContext.LockerRooms.Update(editedLockerRoomDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return LockerRoomDaoConverter.ToRepository(lockerRoomDao);
        }

        public async Task DeleteLockerRoomByFilter(LockerRoomFilterDtoIn filter)
        {
            var query = GetLockerRoomsQuery(filter)
                .AsNoTracking();

            query = GetLockerRoomsQueryWithPaging(query, filter);

            _gameDbContext
                .LockerRooms
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<LockerRoomDao> GetLockerRoomsQuery(LockerRoomFilterDtoIn filter)
        {
            return _gameDbContext
               .LockerRooms
               .Where(
                   lockerRoom =>
                       (filter.Ids == null || filter.Ids.Contains(lockerRoom.Id)) &&
                       (filter.FactionIds == null || filter.FactionIds.Contains(lockerRoom.FactionId))
               )
               .OrderBy(lockerRoom => lockerRoom.Id);
        }

        private IQueryable<LockerRoomDao> GetLockerRoomsQueryWithPaging(IQueryable<LockerRoomDao> query, LockerRoomFilterDtoIn filter)
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
