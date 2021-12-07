namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumModeratorDtoIn(
        int EntityId,
        ForumModeratorEntityTypeDto EntityType,
        int ForumId,
        bool CreateTopics,
        bool CreatePosts,
        bool Read,
        bool EditPosts,
        bool DeleteTopics,
        bool DeletePosts
    );
}
