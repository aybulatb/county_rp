namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class TopicDtoOut
    {
        public int Id { get; }

        public string Caption { get; }

        public int ForumId { get; }

        public TopicDtoOut(
            int id,
            string caption,
            int forumId
        )
        {
            Id = id;
            Caption = caption;
            ForumId = forumId;
        }
    }
}
