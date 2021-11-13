using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site
{
    public partial class SiteService
    {
        public async Task<SiteUserDtoOut> AddUserAsync(SiteUserDtoIn siteUserDtoIn)
        {
            var apiUserDtoIn = SiteUserDtoInConverter.ToExternalApi(siteUserDtoIn);

            var apiUserDtoOut = await _userClient.CreateAsync(apiUserDtoIn);

            return ApiUserDtoOutConverter.ToService(apiUserDtoOut);
        }

        public async Task<SiteUserDtoOut> GetUserByIdAsync(
            int id
        )
        {
            var user = await _userClient.GetByIdAsync(id);

            return ApiUserDtoOutConverter.ToService(user);
        }

        public async Task<SitePagedFilterResultDtoOut<SiteUserDtoOut>> GetUsersByFilterAsync(
            SiteUserFilterDtoIn siteUserFilterDtoIn
        )
        {
            var filteredUsers = await _userClient.FilterByAsync(
                login: siteUserFilterDtoIn.Login,
                loginLike: siteUserFilterDtoIn.LoginLike,
                groupIds: siteUserFilterDtoIn.GroupIds,
                playerIds: siteUserFilterDtoIn.PlayerIds,
                startRegistrationDate: siteUserFilterDtoIn.StartRegistrationDate,
                finishRegistrationDate: siteUserFilterDtoIn.FinishRegistrationDate,
                startLastVisitDate: siteUserFilterDtoIn.StartLastVisitDate,
                finishLastVisitDate: siteUserFilterDtoIn.FinishLastVisitDate,
                count: siteUserFilterDtoIn.Count,
                page: siteUserFilterDtoIn.Page
            );

            return ApiPagedFilterResultDtoOutConverter.ToService(filteredUsers);
        }

        public async Task<SiteUserDtoOut> UpdateUserAsync(SiteUserDtoOut siteUserDtoOut)
        {
            var apiUserDtoIn = SiteUserDtoOutConverter.ToDtoInExternalApi(siteUserDtoOut);

            var apiUserDtoOut = await _userClient.EditAsync(siteUserDtoOut.Id, apiUserDtoIn);

            return ApiUserDtoOutConverter.ToService(apiUserDtoOut);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userClient.DeleteAsync(id);
        }
    }
}
