using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces
{
    public partial interface ISiteService
    {
        Task<SiteUserDtoOut> AddUserAsync(SiteUserDtoIn siteUserDtoIn);

        Task<SiteUserDtoOut> GetUserByIdAsync(int id);

        Task<SitePagedFilterResultDtoOut<SiteUserDtoOut>> GetUsersByFilterAsync(SiteUserFilterDtoIn siteUserFilterDtoIn);

        Task<SiteUserDtoOut> UpdateUserAsync(SiteUserDtoOut siteUserDtoOut);

        Task DeleteUserAsync(int id);
    }
}
