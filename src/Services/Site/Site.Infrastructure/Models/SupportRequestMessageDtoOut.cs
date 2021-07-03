using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public class SupportRequestMessageDtoOut
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; }

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

        public SupportRequestMessageDtoOut(
            int id,
            int topicId,
            string text,
            int userId,
            DateTimeOffset creationDate,
            DateTimeOffset? editionDate
        )
        {
            Id = id;
            TopicId = topicId;
            Text = text;
            UserId = userId;
            CreationDate = creationDate;
            EditionDate = editionDate;
        }
    }
}
