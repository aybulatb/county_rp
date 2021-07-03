using System;

namespace CountyRP.Services.Site.API.Models.Api
{
    public class ApiSupportRequestMessageDtoOut
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор темы.
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// Дата последнего изменения.
        /// </summary>
        public DateTimeOffset? EditionDate { get; set; }

        public ApiSupportRequestMessageDtoOut(
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
