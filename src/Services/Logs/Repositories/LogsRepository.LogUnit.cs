using CountyRP.Services.Logs.Converters;
using CountyRP.Services.Logs.Entities;
using CountyRP.Services.Logs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Logs.Repositories
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
        /// Получить единицу логирования по ID.
        /// </summary>
        public async Task<LogUnitDtoOut> GetLogUnitAsync(int id)
        {
            var logUnit = await _logsDbContext
                .LogUnits
                .AsNoTracking()
                .FirstAsync(logUnit => logUnit.Id == id);

            return LogUnitDaoConverter.ToRepository(logUnit);
        }

        /// <summary>
        /// Получить отфильтрованный список логов.
        /// </summary>
        public async Task<PagedFilterResultDtoOut<LogUnitDtoOut>> GetLogUnitsByFilterAsync(LogUnitFilterDtoIn filter)
        {
            LogActionDao? actionId = filter.ActionId.HasValue
                ? LogActionDtoConverter.ToDb(filter.ActionId.Value)
                : null;

            var logUnitsQuery = _logsDbContext
                .LogUnits
                .AsNoTracking()
                .Where(
                    logUnit =>
                        (filter.StartDateTime == null || logUnit.DateTime >= filter.StartDateTime) &&
                        (filter.FinishDateTime == null || logUnit.DateTime <= filter.FinishDateTime) &&
                        (filter.Login == null || logUnit.Login.Contains(filter.Login)) &&
                        (filter.IP == null || logUnit.IP.Contains(filter.IP)) &&
                        (filter.ActionId == null || logUnit.ActionId == actionId) &&
                        (filter.Text == null || logUnit.Text.Contains(filter.Text))
                )
                .AsQueryable();

            var allCount = await logUnitsQuery.CountAsync();
            var maxPages = (allCount % filter.Count == 0)
                ? allCount / filter.Count
                : allCount / filter.Count + 1;

            var filteredLogUnitsDao = await logUnitsQuery
                .OrderByDescending(logUnit => logUnit.DateTime)
                .Skip(filter.Count * (filter.Page - 1))
                .Take(filter.Count)
                .ToListAsync();

            return new PagedFilterResultDtoOut<LogUnitDtoOut>(
                allCount: allCount,
                page: filter.Page,
                maxPages: maxPages,
                items: filteredLogUnitsDao
                    .Select(LogUnitDaoConverter.ToRepository)
            );
        }

        /// <summary>
        /// Удалить логи по ID.
        /// </summary>
        public async Task DeleteLogUnitByIdAsync(int id)
        {
            var logUnit = await _logsDbContext
                .LogUnits
                .FirstAsync(logUnit => logUnit.Id == id);

            _logsDbContext.LogUnits.Remove(logUnit);
            await _logsDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить все логи, которые старше времени dateTime.
        /// </summary>
        public async Task DeleteLogUnitsByTimeAsync(DateTimeOffset dateTime)
        {
            var logUnits = _logsDbContext
                .LogUnits
                .Where(logUnit => logUnit.DateTime <= dateTime);

            _logsDbContext.LogUnits.RemoveRange(logUnits);
            await _logsDbContext.SaveChangesAsync();
        }
    }
}
