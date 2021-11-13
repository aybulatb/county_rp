using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces
{
    public partial interface ISiteService
    {
        Task<SiteGroupDtoOut> AddGroupAsync(SiteGroupDtoIn groupDtoIn);

        Task<SiteGroupDtoOut> GetGroupByIdAsync(string id);

        Task<SitePagedFilterResultDtoOut<SiteGroupDtoOut>> GetGroupsByFilterAsync(SiteGroupFilterDtoIn filter);

        Task<SiteGroupDtoOut> EditGroupAsync(string id, SiteUpdatedGroupDtoIn updatedGroupDtoIn);

        Task DeleteGroupAsync(string id);
    }
}
