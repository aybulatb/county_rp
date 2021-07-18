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
        public async Task<TeleportDtoOut> AddTeleportAsync(TeleportDtoIn teleportDtoIn)
        {
            var teleportDao = TeleportDtoInConverter.ToDb(teleportDtoIn);

            await _gameDbContext.Teleports.AddAsync(teleportDao);

            await _gameDbContext.SaveChangesAsync();

            return TeleportDaoConverter.ToRepository(teleportDao);
        }

        public async Task<PagedFilterResultDtoOut<TeleportDtoOut>> GetTeleportsByFilter(TeleportFilterDtoIn filter)
        {
            var query = GetTeleportsQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetTeleportsQueryWithPaging(query, filter);

            var filteredTeleports = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<TeleportDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredTeleports
                    .Select(TeleportDaoConverter.ToRepository)
                );
        }

        public async Task<TeleportDtoOut> UpdateTeleportAsync(TeleportDtoOut teleportDtoOut)
        {
            var existedTeleportDao = await _gameDbContext
                .Teleports
                .AsNoTracking()
                .FirstAsync(teleport => teleport.Id == teleportDtoOut.Id);

            var editedTeleportDao = TeleportDtoOutConverter.ToDb(
                source: teleportDtoOut
            );

            var teleportDao = _gameDbContext.Teleports.Update(editedTeleportDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return TeleportDaoConverter.ToRepository(teleportDao);
        }

        public async Task DeleteTeleportByFilter(TeleportFilterDtoIn filter)
        {
            var query = GetTeleportsQuery(filter)
                .AsNoTracking();

            query = GetTeleportsQueryWithPaging(query, filter);

            _gameDbContext
                .Teleports
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<TeleportDao> GetTeleportsQuery(TeleportFilterDtoIn filter)
        {
            return _gameDbContext
               .Teleports
               .Where(
                   teleport =>
                       (filter.Ids == null || filter.Ids.Contains(teleport.Id)) &&
                       (filter.Name == null || filter.Name == teleport.Name) &&
                       (filter.NameLike == null || teleport.Name.Contains(filter.NameLike)) &&
                       (filter.FactionIds == null || filter.FactionIds.Contains(teleport.FactionId)) &&
                       (filter.GangIds == null || filter.GangIds.Contains(teleport.GangId)) &&
                       (filter.RoomIds == null || filter.RoomIds.Contains(teleport.RoomId)) &&
                       (filter.BusinessIds == null || filter.BusinessIds.Contains(teleport.BusinessId))
               )
               .OrderBy(teleport => teleport.Id);
        }

        private IQueryable<TeleportDao> GetTeleportsQueryWithPaging(IQueryable<TeleportDao> query, TeleportFilterDtoIn filter)
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
