namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumUpdatedForumDtoIn(
        string Name,
        int ParentId,
        int Order
    );
}
