using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Implementations
{
    public partial class SiteService
    {
        public async Task<SiteGroupDtoOut> AddGroupAsync(SiteGroupDtoIn groupDtoIn)
        {
            var apiGroupDtoIn = SiteGroupDtoInConverter.ToExternalApi(groupDtoIn);

            var apiGroupDtoOut = await _groupClient.CreateAsync(apiGroupDtoIn);

            return ApiGroupDtoOutConverter.ToService(apiGroupDtoOut);
        }

        public async Task<SiteGroupDtoOut> GetGroupByIdAsync(string id)
        {
            var apiGroupDtoOut = await _groupClient.GetByIdAsync(id);

            return ApiGroupDtoOutConverter.ToService(apiGroupDtoOut);
        }

        public async Task<SitePagedFilterResultDtoOut<SiteGroupDtoOut>> GetGroupsByFilterAsync(SiteGroupFilterDtoIn filter)
        {
            var apiGroupsDtoOut = await _groupClient.FilterByAsync(
                name: filter.Name,
                count: filter.Count,
                page: filter.Page
            );

            return null;
        }

        public async Task<SiteGroupDtoOut> EditGroupAsync(string id, SiteUpdatedGroupDtoIn updatedGroupDtoIn)
        {
            return null;
        }

        public async Task DeleteGroupAsync(string id)
        {
            await _groupClient.DeleteAsync(id);
        }
    }
}
