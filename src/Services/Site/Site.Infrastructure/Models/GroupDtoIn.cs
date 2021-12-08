namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record GroupDtoIn(
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
        int[] BanGroupIds,
        bool SeeLogs
    );
}
