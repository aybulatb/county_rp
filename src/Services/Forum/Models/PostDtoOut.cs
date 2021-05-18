using System;

namespace CountyRP.Services.Forum.Models
{
    public class PostDtoOut
    {
        public int Id { get; }

        public string Text { get; }

        public int TopicId { get; }

        public int UserId { get; }

        public int LastEditorid { get; }

        public DateTimeOffset CreationDateTime { get; }

        public DateTimeOffset EditionDateTime { get; }

        public PostDtoOut(
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
