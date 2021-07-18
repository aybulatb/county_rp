using CountyRP.Services.Game.Infrastructure.Converters;
using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial class GameRepository
    {
        public async Task<GangDtoOut> AddGangAsync(GangDtoIn gangDtoIn)
        {
            var gangDao = GangDtoInConverter.ToDb(gangDtoIn);

            await _gameDbContext.Gangs.AddAsync(gangDao);

            await _gameDbContext.SaveChangesAsync();

            return GangDaoConverter.ToRepository(gangDao);
        }

        public async Task<PagedFilterResultDtoOut<GangDtoOut>> GetGangsByFilter(GangFilterDtoIn filter)
        {
            var query = GetGangsQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetGangsQueryWithPaging(query, filter);

            var filteredGangs = await query
                .ToListAsync();

            return new PagedFilterResultDtoOut<GangDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredGangs
                    .Select(GangDaoConverter.ToRepository)
            );
        }

        public async Task<GangDtoOut> UpdateGangAsync(EditedGangDtoIn editedGangDtoIn)
        {
            var existedGangDao = await _gameDbContext
                .Gangs
                .AsNoTracking()
                .FirstAsync(gang => gang.Id == editedGangDtoIn.Id);

            var editedGangDao = EditedGangDtoInConverter.ToDb(
                source: editedGangDtoIn,
                gangDtoOut: GangDaoConverter.ToRepository(existedGangDao)
            );

            var gangDao = _gameDbContext.Gangs.Update(editedGangDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return GangDaoConverter.ToRepository(gangDao);
        }

        public async Task DeleteGangByFilter(GangFilterDtoIn filter)
        {
            var query = GetGangsQuery(filter)
                .AsNoTracking();

            query = GetGangsQueryWithPaging(query, filter);

            _gameDbContext
                .Gangs
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<GangDao> GetGangsQuery(GangFilterDtoIn filter)
        {
            IEnumerable<GangTypeDao> types = null;
            if (filter.Types != null)
            {
                filter.Types
                    .Select(GangTypeDtoConverter.ToDb);
            }

            return _gameDbContext
               .Gangs
               .Where(
                   gang =>
                       (filter.Ids == null || filter.Ids.Contains(gang.Id)) &&
                       (filter.Name == null || filter.Name == gang.Name) &&
                       (filter.NameLike == null || gang.Name.Contains(filter.NameLike)) &&
                       (types == null || types.Contains(gang.Type))
               )
               .OrderBy(gang => gang.Id);
        }

        private IQueryable<GangDao> GetGangsQueryWithPaging(IQueryable<GangDao> query, GangFilterDtoIn filter)
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
