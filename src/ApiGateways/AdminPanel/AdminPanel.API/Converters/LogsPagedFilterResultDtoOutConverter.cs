using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal class LogsPagedFilterResultDtoOutConverter
    {
        public static ApiPagedFilterResultDtoOut<ApiLogUnitDtoOut> ToApi(
            LogsPagedFilterResultDtoOut<LogsLogUnitDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiLogUnitDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(LogsLogUnitDtoOutConverter.ToApi)
            );
        }
    }
}
