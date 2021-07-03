using System;

namespace CountyRP.Services.Site.API.Models.Api
{
    public class ApiSupportRequestTopicDtoOut
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        public ApiSupportRequestTopicTypeDto Type { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public ApiSupportRequestTopicStatusDto Status { get; set; }

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

        public ApiSupportRequestTopicDtoOut(
            int id,
            ApiSupportRequestTopicTypeDto type,
            string caption,
            ApiSupportRequestTopicStatusDto status,
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
