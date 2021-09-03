using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces
{
    public partial interface ISiteService
    {
        Task<SitePagedFilterResultDtoOut<SiteUserDtoOut>> GetUsersByFilter(SiteUserFilterDtoIn siteUserFilterDtoIn);
    }
}
