using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Site.Entities
{
    public class SupportRequestMessageDao
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

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

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public SupportRequestMessageDao()
        {
        }

        public SupportRequestMessageDao(
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
