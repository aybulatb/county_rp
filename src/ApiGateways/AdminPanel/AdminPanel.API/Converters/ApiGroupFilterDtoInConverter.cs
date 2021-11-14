using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal class ApiGroupFilterDtoInConverter
    {
        public static SiteGroupFilterDtoIn ToService(
            ApiGroupFilterDtoIn source
        )
        {
            return new SiteGroupFilterDtoIn(
                Count: source.Count,
                Page: source.Page,
                Name: source.Name
            );
        }
    }
}
