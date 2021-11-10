using System;

namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiSupportRequestTopicDtoOut
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Тип.
        /// </summary>
        public ApiSupportRequestTopicTypeDto Type { get; init; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Caption { get; init; }

        /// <summary>
        /// Статус.
        /// </summary>
        public ApiSupportRequestTopicStatusDto Status { get; init; }

        /// <summary>
        /// Идентификатор пользователя-создателя.
        /// </summary>
        public int CreatorUserId { get; init; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTimeOffset CreationDate { get; init; }

        /// <summary>
        /// Идентификатор ссылочного пользователя.
        /// </summary>
        public int? RefUserId { get; init; }

        /// <summary>
        /// Видимость обращения для ссылочного пользователя.
        /// </summary>
        public bool ShowRefUser { get; init; }

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
