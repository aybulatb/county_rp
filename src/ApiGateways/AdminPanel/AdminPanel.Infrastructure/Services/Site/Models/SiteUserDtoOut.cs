namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public record SiteUserDtoOut(
        int Id,
        string Login,
        string Password,
        int PlayerId,
        int ForumUserId,
        int GroupId
    );
}
