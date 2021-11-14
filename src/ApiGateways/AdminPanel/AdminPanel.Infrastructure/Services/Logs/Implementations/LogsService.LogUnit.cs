using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Implementations
{
    public partial class LogsService
    {
        public async Task<LogsLogUnitDtoOut> CreateLogUnitAsync(LogsLogUnitDtoIn logUnitDtoIn)
        {
            var apiLogUnitDtoIn = LogsLogUnitDtoInConverter.ToExternalApi(logUnitDtoIn);

            var apiLogUnitDtoOut = await _logUnitClient.CreateAsync(apiLogUnitDtoIn);

            return ApiLogUnitDtoOutConverter.ToService(apiLogUnitDtoOut);
        }

        public async Task<LogsPagedFilterResultDtoOut<LogsLogUnitDtoOut>> GetLogUnitsByFilterAsync(LogsLogUnitFilterDtoIn filter)
        {
            var filteredLogUnitsDtoOut = await _logUnitClient.FilterByAsync(
                ids: filter.Ids,
                startDateTime: filter.StartDateTime,
                finishDateTime: filter.FinishDateTime,
                login: filter.Login,
                iP: filter.IP,
                actionId: filter.ActionType.HasValue
                    ? LogsLogActionTypeDtoConverter.ToExternalApi(filter.ActionType.Value)
                    : null,
                text: filter.Text,
                count: filter.Count,
                page: filter.Page
            );

            return ApiPagedFilterResultDtoOutConverter.ToService(filteredLogUnitsDtoOut);
        }
    }
}
