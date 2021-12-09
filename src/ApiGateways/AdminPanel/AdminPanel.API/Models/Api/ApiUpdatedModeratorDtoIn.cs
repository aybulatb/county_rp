namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiUpdatedModeratorDtoIn
    {
        public int Id { get; init; }

        public bool CreateTopics { get; init; }

        public bool CreatePosts { get; init; }

        public bool Read { get; init; }

        public bool EditPosts { get; init; }

        public bool DeleteTopics { get; init; }

        public bool DeletePosts { get; init; }

        public ApiUpdatedModeratorDtoIn(
            int id,
            bool createTopics,
            bool createPosts,
            bool read,
            bool editPosts,
            bool deleteTopics,
            bool deletePosts
        )
        {
            Id = id;
            CreateTopics = createTopics;
            CreatePosts = createPosts;
            Read = read;
            EditPosts = editPosts;
            DeleteTopics = deleteTopics;
            DeletePosts = deletePosts;
        }
    }
}
