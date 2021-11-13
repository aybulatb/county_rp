namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public record SiteUserDtoIn(
        string Login,
        string Password,
        int PlayerId,
        int ForumUserId,
        string GroupId
    );
}
