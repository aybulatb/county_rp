using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces
{
    public partial interface ISiteService
    {
        Task<SiteGroupDtoOut> AddGroupAsync(SiteGroupDtoIn groupDtoIn);

        Task<SiteGroupDtoOut> GetGroupByIdAsync(int id);

        Task<SitePagedFilterResultDtoOut<SiteGroupDtoOut>> GetGroupsByFilterAsync(SiteGroupFilterDtoIn filter);

        Task<SiteGroupDtoOut> EditGroupAsync(int id, SiteUpdatedGroupDtoIn updatedGroupDtoIn);

        Task DeleteGroupAsync(int id);
    }
}
