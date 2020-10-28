using System;

namespace CountyRP.Forum.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TopicId { get; set; }
        public int UserId { get; set; }
        public int LastEditorid { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime EditionDateTime { get; set; }
    }
}
