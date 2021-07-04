using CountyRP.Services.Logs.Infrastructure.Models;
using System;
using System.Threading.Tasks;

namespace CountyRP.Services.Logs.Infrastructure.Repositories
{
    public partial interface ILogsRepository
    {
        /// <summary>
        /// Создать единицу логирования.
        /// </summary>
        Task<LogUnitDtoOut> AddLogUnitAsync(LogUnitDtoIn logUnitDtoIn);

        /// <summary>
        /// Получить единицу логирования по ID.
        /// </summary>
        Task<LogUnitDtoOut> GetLogUnitAsync(int id);

        /// <summary>
        /// Получить отфильтрованный список логов.
        /// </summary>
        Task<PagedFilterResultDtoOut<LogUnitDtoOut>> GetLogUnitsByFilterAsync(LogUnitFilterDtoIn filter);

        /// <summary>
        /// Удалить логи по ID.
        /// </summary>
        Task DeleteLogUnitByIdAsync(int id);

        /// <summary>
        /// Удалить все логи, которые старше времени dateTime.
        /// </summary>
        Task DeleteLogUnitsByTimeAsync(DateTimeOffset dateTime);
    }
}
