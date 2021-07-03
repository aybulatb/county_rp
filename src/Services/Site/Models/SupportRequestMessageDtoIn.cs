using System;

namespace CountyRP.Services.Site.Models
{
    public class SupportRequestMessageDtoIn
    {
        /// <summary>
        /// Идентификатор темы.
        /// </summary>
        public int TopicId { get; }

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int UserId { get; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTimeOffset CreationDate { get; }

        /// <summary>
        /// Дата последнего изменения.
        /// </summary>
        public DateTimeOffset? EditionDate { get; }

        public SupportRequestMessageDtoIn(
            int topicId,
            string text,
            int userId,
            DateTimeOffset creationDate,
            DateTimeOffset? editionDate
        )
        {
            TopicId = topicId;
            Text = text;
            UserId = userId;
            CreationDate = creationDate;
            EditionDate = editionDate;
        }
    }
}
