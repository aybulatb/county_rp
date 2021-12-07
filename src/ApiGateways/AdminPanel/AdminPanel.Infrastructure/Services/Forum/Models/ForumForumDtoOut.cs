namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumForumDtoOut(
        int Id,
        string Name,
        int ParentId,
        int Order
    );
}
