namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumForumDtoIn(
        string Name,
        int ParentId,
        int Order
    );
}
