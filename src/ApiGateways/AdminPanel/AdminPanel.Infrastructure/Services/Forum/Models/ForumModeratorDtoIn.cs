namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumModeratorDtoIn(
        int EntityId,
        int EntityType,
        int ForumId,
        bool CreateTopics,
        bool CreatePosts,
        bool Read,
        bool EditPosts,
        bool DeleteTopics,
        bool DeletePosts
    );
}
