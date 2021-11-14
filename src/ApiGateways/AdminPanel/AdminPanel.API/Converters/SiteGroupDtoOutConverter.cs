using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class SiteGroupDtoOutConverter
    {
        public static ApiGroupDtoOut ToApi(
            SiteGroupDtoOut source
        )
        {
            return new ApiGroupDtoOut(
                id: source.Id,
                name: source.Name,
                color: source.Color,
                admin: source.Admin,
                adminPanel: source.AdminPanel,
                createUsers: source.CreateUsers,
                deleteUsers: source.DeleteUsers,
                changeLogin: source.ChangeLogin,
                changeGroup: source.ChangeGroup,
                editGroups: source.EditGroups,
                maxBan: source.MaxBan,
                banGroupIds: source.BanGroupIds,
                seeLogs: source.SeeLogs
            );
        }
    }
}
