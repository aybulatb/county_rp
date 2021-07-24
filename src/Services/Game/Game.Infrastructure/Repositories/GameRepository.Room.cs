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
        public async Task<RoomDtoOut> AddRoomAsync(RoomDtoIn roomDtoIn)
        {
            var roomDao = RoomDtoInConverter.ToDb(roomDtoIn);

            await _gameDbContext.Rooms.AddAsync(roomDao);

            await _gameDbContext.SaveChangesAsync();

            return RoomDaoConverter.ToRepository(roomDao);
        }

        public async Task<PagedFilterResultDtoOut<RoomDtoOut>> GetRoomsByFilter(RoomFilterDtoIn filter)
        {
            var query = GetRoomsQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetRoomsQueryWithPaging(query, filter);

            var filteredRooms = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<RoomDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredRooms
                    .Select(RoomDaoConverter.ToRepository)
                );
        }

        public async Task<RoomDtoOut> UpdateRoomAsync(RoomDtoOut roomDtoOut)
        {
            var existedRoomDao = await _gameDbContext
                .Rooms
                .AsNoTracking()
                .FirstAsync(room => room.Id == roomDtoOut.Id);

            var editedRoomDao = RoomDtoOutConverter.ToDb(
                source: roomDtoOut
            );

            var roomDao = _gameDbContext.Rooms.Update(editedRoomDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return RoomDaoConverter.ToRepository(roomDao);
        }

        public async Task DeleteRoomByFilter(RoomFilterDtoIn filter)
        {
            var query = GetRoomsQuery(filter)
                .AsNoTracking();

            query = GetRoomsQueryWithPaging(query, filter);

            _gameDbContext
                .Rooms
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<RoomDao> GetRoomsQuery(RoomFilterDtoIn filter)
        {
            return _gameDbContext
               .Rooms
               .Where(
                   room =>
                       (filter.Ids == null || filter.Ids.Contains(room.Id)) &&
                       (filter.Name == null || filter.Name == room.Name) &&
                       (filter.NameLike == null || room.Name.Contains(filter.NameLike)) &&
                       (filter.GangIds == null || filter.GangIds.Contains(room.GangId.Value)) &&
                       (filter.StartLastPaymentDate == null || room.LastPaymentDate >= filter.StartLastPaymentDate) &&
                       (filter.FinishLastPaymentDate == null || room.LastPaymentDate <= filter.FinishLastPaymentDate)
               )
               .OrderBy(room => room.Id);
        }

        private IQueryable<RoomDao> GetRoomsQueryWithPaging(IQueryable<RoomDao> query, RoomFilterDtoIn filter)
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
