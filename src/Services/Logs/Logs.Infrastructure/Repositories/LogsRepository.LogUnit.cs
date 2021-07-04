using CountyRP.Services.Logs.Infrastructure.Converters;
using CountyRP.Services.Logs.Infrastructure.Entities;
using CountyRP.Services.Logs.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Logs.Infrastructure.Repositories
{
    public partial class LogsRepository
    {
        /// <summary>
        /// Создать единицу логирования.
        /// </summary>
        public async Task<LogUnitDtoOut> AddLogUnitAsync(LogUnitDtoIn logUnitDtoIn)
        {
            var logUnitDao = LogUnitDtoInConverter.ToDb(logUnitDtoIn);

            await _logsDbContext.LogUnits.AddAsync(logUnitDao);
            await _logsDbContext.SaveChangesAsync();

            return LogUnitDaoConverter.ToRepository(logUnitDao);
        }

        /// <summary>
        /// Получить отфильтрованный список логов.
        /// </summary>
        public async Task<PagedFilterResultDtoOut<LogUnitDtoOut>> GetLogUnitsByFilterAsync(LogUnitFilterDtoIn filter)
        {
            LogActionDao? actionId = (filter.ActionId.HasValue == true)
                ? LogActionDtoConverter.ToDb(filter.ActionId.Value)
                : null;

            var logUnitsQuery = GetLogUnitsByFilterQuery(filter);

            var allCount = await logUnitsQuery.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            logUnitsQuery = GetLogUnitsQueryWithPaging(filter, logUnitsQuery);

            var filteredLogUnitsDao = await logUnitsQuery
                .ToListAsync();

            return new PagedFilterResultDtoOut<LogUnitDtoOut>(
                allCount: allCount,
                page: filter.Page.HasValue
                    ? filter.Page.Value
                    : 1,
                maxPages: maxPages,
                items: filteredLogUnitsDao
                    .Select(LogUnitDaoConverter.ToRepository)
            );
        }

        /// <summary>
        /// Удалить логи.
        /// </summary>
        public async Task DeleteLogUnitsAsync(LogUnitFilterDtoIn filter)
        {
            var query = GetLogUnitsByFilterQuery(filter);

            query = GetLogUnitsQueryWithPaging(filter, query);

            _logsDbContext.LogUnits.RemoveRange(query);
            await _logsDbContext.SaveChangesAsync();
        }

        private IQueryable<LogUnitDao> GetLogUnitsByFilterQuery(LogUnitFilterDtoIn filter)
        {
            LogActionDao? actionId = (filter.ActionId.HasValue == true)
                ? LogActionDtoConverter.ToDb(filter.ActionId.Value)
                : null;

            var logUnitsQuery = _logsDbContext
                .LogUnits
                .AsNoTracking()
                .Where(
                    logUnit =>
                        (filter.Ids == null || filter.Ids.Contains(logUnit.Id)) &&
                        (filter.StartDateTime == null || logUnit.DateTime >= filter.StartDateTime) &&
                        (filter.FinishDateTime == null || logUnit.DateTime <= filter.FinishDateTime) &&
                        (filter.Login == null || logUnit.Login.Contains(filter.Login)) &&
                        (filter.IP == null || logUnit.IP.Contains(filter.IP)) &&
                        (filter.ActionId == null || logUnit.ActionId == actionId) &&
                        (filter.Text == null || logUnit.Text.Contains(filter.Text))
                )
                .OrderByDescending(logUnit => logUnit.DateTime);

            return logUnitsQuery;
        }

        private IQueryable<LogUnitDao> GetLogUnitsQueryWithPaging(
            LogUnitFilterDtoIn filter,
            IQueryable<LogUnitDao> query
        )
        {
            if (filter.Count.HasValue && filter.Page.HasValue && filter.Count.Value > 0 && filter.Page.Value > 0)
            {
                query = query
                    .Skip(filter.Count.Value * (filter.Page.Value - 1))
                    .Take(filter.Count.Value);
            }

            return query;
        }
    }
}
