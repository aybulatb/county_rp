namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record GroupDtoOut(
        int Id,
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
