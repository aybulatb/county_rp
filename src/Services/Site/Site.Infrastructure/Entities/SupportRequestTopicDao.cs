using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Site.Infrastructure.Entities
{
    public class SupportRequestTopicDao
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        /// <summary>
        /// Тип.
        /// </summary>
        public SupportRequestTopicTypeDao Type { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        [MaxLength(128)]
        public string Caption { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public SupportRequestTopicStatusDao Status { get; set; }

        /// <summary>
        /// Идентификатор пользователя-создателя.
        /// </summary>
        public int CreatorUserId { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// Идентификатор ссылочного пользователя.
        /// </summary>
        public int? RefUserId { get; set; }

        /// <summary>
        /// Видимость обращения для ссылочного пользователя.
        /// </summary>
        public bool ShowRefUser { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public SupportRequestTopicDao()
        {
        }

        public SupportRequestTopicDao(
            int id,
            SupportRequestTopicTypeDao type,
            string caption,
            SupportRequestTopicStatusDao status,
            int creatorUserId,
            DateTimeOffset creationDate,
            int? refUserId,
            bool showRefUser
        )
        {
            Id = id;
            Type = type;
            Caption = caption;
            Status = status;
            CreatorUserId = creatorUserId;
            CreationDate = creationDate;
            RefUserId = refUserId;
            ShowRefUser = showRefUser;
        }
    }
}
