namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumUpdatedOrderedForumDtoIn(
        int Id,
        int ParentId,
        int Order
    );
}
