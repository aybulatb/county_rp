using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class PostDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Text { get; set; }

        public int TopicId { get; set; }

        public int UserId { get; set; }

        public int LastEditorid { get; set; }

        public DateTimeOffset CreationDateTime { get; set; }

        public DateTimeOffset EditionDateTime { get; set; }

        public PostDao(
            int id,
            string text,
            int topicId,
            int userId,
            int lastEditorId,
            DateTimeOffset creationDateTime,
            DateTimeOffset editionDateTime
        )
        {
            Id = id;
            Text = text;
            TopicId = topicId;
            UserId = userId;
            LastEditorid = lastEditorId;
            CreationDateTime = creationDateTime;
            EditionDateTime = editionDateTime;
        }
    }
}
