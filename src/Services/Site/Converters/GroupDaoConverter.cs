using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
{
    internal static class GroupDaoConverter
    {
        public static GroupDtoOut ToRepository(
            GroupDao source
        )
        {
            return new GroupDtoOut(
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
