using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public record SiteGroupDtoOut(
        string Id,
        string Name,
        string Color,
        bool Admin,
        bool AdminPanel,
        bool CreateUsers,
        bool DeleteUsers,
        bool ChangeLogin,
        bool ChangeGroup,
        bool EditGroups,
        int MaxBan,
        IEnumerable<string> BanGroupIds,
        bool SeeLogs
    );
}
