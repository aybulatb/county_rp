namespace CountyRP.Forum.Domain.Models
{
    public class Moderator
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int EntityType { get; set; }
        public int ForumId { get; set; }
        public bool CreateTopics { get; set; }
        public bool CreatePosts { get; set; }
        public bool Read { get; set; }
        public bool EditPosts { get; set; }
        public bool DeleteTopics { get; set; }
        public bool DeletePosts { get; set; }
    }
}
