using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Converters
{
    internal static class ApiPagedFilterResultDtoOutConverter
    {
        public static SitePagedFilterResultDtoOut<SiteUserDtoOut> ToService(
            ApiPagedFilterResultOfApiUserDtoOut source
        )
        {
            return new SitePagedFilterResultDtoOut<SiteUserDtoOut>(
                AllCount: source.AllCount,
                Page: source.Page,
                MaxPages: source.MaxPages,
                Items: source.Items
                    .Select(ApiUserDtoOutConverter.ToService)
                );
        }

        public static SitePagedFilterResultDtoOut<SiteGroupDtoOut> ToService(
            ApiPagedFilterResultOfApiGroupDtoOut source
        )
        {
            return new SitePagedFilterResultDtoOut<SiteGroupDtoOut>(
                AllCount: source.AllCount,
                Page: source.Page,
                MaxPages: source.MaxPages,
                Items: source.Items
                    .Select(ApiGroupDtoOutConverter.ToService)
            );
        }
    }
}
