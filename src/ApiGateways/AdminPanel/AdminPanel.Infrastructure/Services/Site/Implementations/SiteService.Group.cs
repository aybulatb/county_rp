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

        public async Task<SiteGroupDtoOut> GetGroupByIdAsync(int id)
        {
            var apiGroupDtoOut = await _groupClient.GetByIdAsync(id);

            return ApiGroupDtoOutConverter.ToService(apiGroupDtoOut);
        }

        public async Task<SitePagedFilterResultDtoOut<SiteGroupDtoOut>> GetGroupsByFilterAsync(SiteGroupFilterDtoIn filter)
        {
            var apiGroupsDtoOut = await _groupClient.FilterByAsync(
                ids: filter.Ids,
                name: filter.Name,
                count: filter.Count,
                page: filter.Page
            );

            return ApiPagedFilterResultDtoOutConverter.ToService(apiGroupsDtoOut);
        }

        public async Task<SiteGroupDtoOut> EditGroupAsync(int id, SiteUpdatedGroupDtoIn updatedGroupDtoIn)
        {
            var apiUpdatedGroupDtoIn = SiteUpdatedGroupDtoInConverter.ToExternalApi(updatedGroupDtoIn);

            var apiGroupDtoOut = await _groupClient.EditAsync(id, apiUpdatedGroupDtoIn);

            return ApiGroupDtoOutConverter.ToService(apiGroupDtoOut);
        }

        public async Task DeleteGroupAsync(int id)
        {
            await _groupClient.DeleteAsync(id);
        }
    }
}
