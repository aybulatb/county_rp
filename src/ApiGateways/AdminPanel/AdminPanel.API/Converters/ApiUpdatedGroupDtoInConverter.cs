using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal class ApiUpdatedGroupDtoInConverter
    {
        public static SiteUpdatedGroupDtoIn ToService(
            ApiUpdatedGroupDtoIn source
        )
        {
            return new SiteUpdatedGroupDtoIn(
                Name: source.Name,
                Color: source.Color,
                Admin: source.Admin,
                AdminPanel: source.AdminPanel,
                CreateUsers: source.CreateUsers,
                DeleteUsers: source.DeleteUsers,
                ChangeLogin: source.ChangeLogin,
                ChangeGroup: source.ChangeGroup,
                EditGroups: source.EditGroups,
                MaxBan: source.MaxBan,
                BanGroupIds: source.BanGroupIds,
                SeeLogs: source.SeeLogs
            );
        }
    }
}
