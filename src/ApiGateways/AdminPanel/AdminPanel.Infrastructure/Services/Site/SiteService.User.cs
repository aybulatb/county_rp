using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site
{
    public partial class SiteService
    {
        public async Task<SitePagedFilterResultDtoOut<SiteUserDtoOut>> GetUsersByFilter(
            SiteUserFilterDtoIn siteUserFilterDtoIn
        )
        {
            await _userClient.FilterByAsync(
                login: siteUserFilterDtoIn.Login,
                groupIds: siteUserFilterDtoIn.GroupIds,
                count: siteUserFilterDtoIn.Count,
                page: siteUserFilterDtoIn.Page
            );

            return null;
        }
    }
}
