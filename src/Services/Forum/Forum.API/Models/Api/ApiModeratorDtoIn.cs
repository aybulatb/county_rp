namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiModeratorDtoIn
    {
        public int EntityId { get; set; }

        public ApiModeratorEntityTypeDto EntityType { get; set; }

        public int ForumId { get; set; }

        public bool CreateTopics { get; set; }

        public bool CreatePosts { get; set; }

        public bool Read { get; set; }

        public bool EditPosts { get; set; }

        public bool DeleteTopics { get; set; }

        public bool DeletePosts { get; set; }
    }
}
