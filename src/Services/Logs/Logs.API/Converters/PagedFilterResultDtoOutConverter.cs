using CountyRP.Services.Logs.API.Models.Api;
using CountyRP.Services.Logs.Infrastructure.Models;
using System.Linq;

namespace CountyRP.Services.Logs.API.Converters
{
    public static class PagedFilterResultDtoOutConverter
    {
        public static ApiPagedFilterResultDtoOut<ApiLogUnitDtoOut> ToApi(
            PagedFilterResultDtoOut<LogUnitDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiLogUnitDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items.Select(LogUnitDtoOutConverter.ToApi)
            );
        }
    }
}
