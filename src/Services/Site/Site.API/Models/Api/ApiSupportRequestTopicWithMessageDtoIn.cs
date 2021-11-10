using System;

namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiSupportRequestTopicWithMessageDtoIn
    {
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

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Text { get; init; }
    }
}
