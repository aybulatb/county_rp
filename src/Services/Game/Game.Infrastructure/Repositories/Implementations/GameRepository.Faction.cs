using CountyRP.Services.Game.Infrastructure.Converters;
using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories.Implementations
{
    public partial class GameRepository
    {
        public async Task<FactionDtoOut> AddFactionAsync(FactionDtoIn factionDtoIn)
        {
            var factionDao = FactionDtoInConverter.ToDb(factionDtoIn);

            await _gameDbContext.Factions.AddAsync(factionDao);

            await _gameDbContext.SaveChangesAsync();

            return FactionDaoConverter.ToRepository(factionDao);
        }

        public async Task<PagedFilterResultDtoOut<FactionDtoOut>> GetFactionsByFilter(FactionFilterDtoIn filter)
        {
            var query = GetFactionsQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetFactionsQueryWithPaging(query, filter);

            var filteredFactions = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<FactionDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredFactions
                    .Select(FactionDaoConverter.ToRepository)
                );
        }

        public async Task<FactionDtoOut> UpdateFactionAsync(FactionDtoOut factionDtoOut)
        {
            var existedFactionDao = await _gameDbContext
                .Factions
                .AsNoTracking()
                .FirstAsync(faction => faction.Id == factionDtoOut.Id);

            var editedFactionDao = FactionDtoOutConverter.ToDb(
                source: factionDtoOut
            );

            var factionDao = _gameDbContext.Factions.Update(editedFactionDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return FactionDaoConverter.ToRepository(factionDao);
        }

        public async Task DeleteFactionByFilter(FactionFilterDtoIn filter)
        {
            var query = GetFactionsQuery(filter)
                .AsNoTracking();

            query = GetFactionsQueryWithPaging(query, filter);

            _gameDbContext
                .Factions
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<FactionDao> GetFactionsQuery(FactionFilterDtoIn filter)
        {
            IEnumerable<FactionTypeDao> types = null;
            if (filter.Types != null)
            {
                filter.Types
                    .Select(FactionTypeDtoConverter.ToDb);
            }

            return _gameDbContext
               .Factions
               .Where(
                   faction =>
                       (filter.Ids == null || filter.Ids.Contains(faction.Id)) &&
                       (filter.IdLike == null || faction.Id.Contains(filter.IdLike)) &&
                       (filter.Names == null || filter.Names.Contains(faction.Name)) &&
                       (filter.NameLike == null || faction.Name.Contains(filter.NameLike)) &&
                       (types == null || types.Contains(faction.Type))
               )
               .OrderBy(faction => faction.Id);
        }

        private IQueryable<FactionDao> GetFactionsQueryWithPaging(IQueryable<FactionDao> query, FactionFilterDtoIn filter)
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
