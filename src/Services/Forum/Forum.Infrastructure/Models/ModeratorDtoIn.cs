namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class ModeratorDtoIn
    {
        public int EntityId { get; }

        public int EntityType { get; }

        public int ForumId { get; }

        public bool CreateTopics { get; }

        public bool CreatePosts { get; }

        public bool Read { get; }

        public bool EditPosts { get; }

        public bool DeleteTopics { get; }

        public bool DeletePosts { get; }


        public ModeratorDtoIn(
            int entityId,
            int entityType,
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
