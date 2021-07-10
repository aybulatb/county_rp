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
        public async Task<PlayerDtoOut> AddPlayerAsync(PlayerDtoIn playerDtoIn)
        {
            var playerDao = PlayerDtoInConverter.ToDb(playerDtoIn);

            await _gameDbContext.Players.AddAsync(playerDao);

            await _gameDbContext.SaveChangesAsync();

            return PlayerDaoConverter.ToRepository(playerDao);
        }

        public async Task<PagedFilterResultDtoOut<PlayerDtoOut>> GetPlayersByFilter(PlayerFilterDtoIn filter)
        {
            var query = GetPlayersQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetPlayersQueryWithPaging(query, filter);

            var filteredPlayers = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<PlayerDtoOut>(
                allCount: allCount,
                page: filter.Page.HasValue
                    ? filter.Page.Value
                    : 1,
                maxPages: maxPages,
                items: filteredPlayers
                    .Select(PlayerDaoConverter.ToRepository)
                );
        }

        public async Task DeletePlayerByFilter(PlayerFilterDtoIn filter)
        {
            var query = GetPlayersQuery(filter)
                .AsNoTracking();

            query = GetPlayersQueryWithPaging(query, filter);

            _gameDbContext
                .Players
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<PlayerDao> GetPlayersQuery(PlayerFilterDtoIn filter)
        {
            return _gameDbContext
               .Players
               .Where(
                   player =>
                       (filter.Ids == null || filter.Ids.Contains(player.Id)) &&
                       (filter.Logins == null || filter.Logins.Contains(player.Login)) &&
                       (filter.StartRegistrationDate == null || player.RegistrationDate > filter.StartRegistrationDate) &&
                       (filter.FinishRegistrationDate == null || player.RegistrationDate > filter.FinishRegistrationDate) &&
                       (filter.StartLastVisitDate == null || player.LastVisitDate > filter.StartLastVisitDate) &&
                       (filter.FinishLastVisitDate == null || player.LastVisitDate > filter.FinishLastVisitDate)
               );
        }

        private IQueryable<PlayerDao> GetPlayersQueryWithPaging(IQueryable<PlayerDao> query, PlayerFilterDtoIn filter)
        {
            if (filter.Page.HasValue && filter.Count.HasValue && filter.Count.Value > 0 && filter.Page > 0)
            {
                query = query
                   .Skip((filter.Page.Value - 1) * filter.Count.Value)
                   .Take(filter.Count.Value);
            }

            return query;
        }
    }
}
