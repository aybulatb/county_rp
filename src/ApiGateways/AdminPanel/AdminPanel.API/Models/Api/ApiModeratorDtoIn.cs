namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiModeratorDtoIn
    {
        public int EntityId { get; init; }

        public ApiModeratorEntityTypeDto EntityType { get; init; }

        public int ForumId { get; init; }

        public bool CreateTopics { get; init; }

        public bool CreatePosts { get; init; }

        public bool Read { get; init; }

        public bool EditPosts { get; init; }

        public bool DeleteTopics { get; init; }

        public bool DeletePosts { get; init; }

        public ApiModeratorDtoIn(
            int entityId,
            ApiModeratorEntityTypeDto entityType,
            int forumId,
            bool createTopics,
            bool createPosts,
            bool read,
            bool editPosts,
            bool deleteTopics,
            bool deletePosts
        )
        {
            EntityId = entityId;
            EntityType = entityType;
            ForumId = forumId;
            CreateTopics = createTopics;
            CreatePosts = createPosts;
            Read = read;
            EditPosts = editPosts;
            DeleteTopics = deleteTopics;
            DeletePosts = deletePosts;
        }
    }
}
