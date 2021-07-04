using CountyRP.Services.Logs.Infrastructure.Models;
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
        /// Получить отфильтрованный список логов.
        /// </summary>
        Task<PagedFilterResultDtoOut<LogUnitDtoOut>> GetLogUnitsByFilterAsync(LogUnitFilterDtoIn filter);

        /// <summary>
        /// Удалить логи.
        /// </summary>
        Task DeleteLogUnitsAsync(LogUnitFilterDtoIn filter);
    }
}
