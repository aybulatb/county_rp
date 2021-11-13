using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Converters
{
    internal static class SiteGroupDtoInConverter
    {
        public static ApiGroupDtoIn ToExternalApi(
            SiteGroupDtoIn source
        )
        {
            return new ApiGroupDtoIn
            {
                Id = source.Id,
                Name = source.Name,
                Color = source.Color,
                Admin = source.Admin,
                AdminPanel = source.AdminPanel,
                CreateUsers = source.CreateUsers,
                DeleteUsers = source.DeleteUsers,
                ChangeLogin = source.ChangeLogin,
                ChangeGroup = source.ChangeGroup,
                EditGroups = source.EditGroups,
                MaxBan = source.MaxBan,
                BanGroupIds = source.BanGroupIds,
                SeeLogs = source.SeeLogs
            };
        }
    }
}
