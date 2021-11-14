using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Interfaces
{
    public partial interface ILogsService
    {
        Task<LogsLogUnitDtoOut> CreateLogUnitAsync(LogsLogUnitDtoIn logUnitDtoIn);

        Task<LogsPagedFilterResultDtoOut<LogsLogUnitDtoOut>> GetLogUnitsByFilterAsync(LogsLogUnitFilterDtoIn filter);
    }
}
