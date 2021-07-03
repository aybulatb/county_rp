using System;

namespace CountyRP.Services.Site.Models
{
    public class SupportRequestTopicDtoOut
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Тип.
        /// </summary>
        public SupportRequestTopicTypeDto Type { get; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Caption { get; }

        /// <summary>
        /// Статус.
        /// </summary>
        public SupportRequestTopicStatusDto Status { get; }

        /// <summary>
        /// Идентификатор пользователя-создателя.
        /// </summary>
        public int CreatorUserId { get; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTimeOffset CreationDate { get; }

        /// <summary>
        /// Идентификатор ссылочного пользователя.
        /// </summary>
        public int? RefUserId { get; }

        /// <summary>
        /// Видимость обращения для ссылочного пользователя.
        /// </summary>
        public bool ShowRefUser { get; }

        public SupportRequestTopicDtoOut(
            int id,
            SupportRequestTopicTypeDto type,
            string caption,
            SupportRequestTopicStatusDto status,
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
