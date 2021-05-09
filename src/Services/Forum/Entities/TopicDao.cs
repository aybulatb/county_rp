using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class TopicDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Caption { get; set; }

        public int ForumId { get; set; }

        public TopicDao(
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
