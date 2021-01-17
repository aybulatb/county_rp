namespace CountyRP.Forum.Domain.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public int ForumId { get; set; }
    }
}
