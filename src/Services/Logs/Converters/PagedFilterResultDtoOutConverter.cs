using CountyRP.Services.Logs.Models;
using CountyRP.Services.Logs.Models.Api;
using System.Linq;

namespace CountyRP.Services.Logs.Converters
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
