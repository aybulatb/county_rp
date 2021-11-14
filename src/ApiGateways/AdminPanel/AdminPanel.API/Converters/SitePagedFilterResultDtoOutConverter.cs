using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal class SitePagedFilterResultDtoOutConverter
    {
        public static ApiPagedFilterResultDtoOut<ApiGroupDtoOut> ToApi(
            SitePagedFilterResultDtoOut<SiteGroupDtoOut> source
        )
        {
            return new ApiPagedFilterResultDtoOut<ApiGroupDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items
                    .Select(SiteGroupDtoOutConverter.ToApi)
            );
        }
    }
}
