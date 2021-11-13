namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public record SiteUpdatedGroupDtoIn(
        string Name,
        string Color,
        bool Admin,
        bool AdminPanel,
        bool CreateUsers,
        bool DeleteUsers,
        bool ChangeGroup,
        bool EditGroups,
        int MaxBan,
        string[] BanGroupIds,
        bool SeeLogs
    );
}
