using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    internal static class ApiGroupDtoInConverter
    {
        public static GroupDtoIn ToRepository(
            ApiGroupDtoIn source
        )
        {
            return new GroupDtoIn(
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
