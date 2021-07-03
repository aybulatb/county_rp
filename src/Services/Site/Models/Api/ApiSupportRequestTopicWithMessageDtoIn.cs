using System;

namespace CountyRP.Services.Site.Models.Api
{
    public class ApiSupportRequestTopicWithMessageDtoIn
    {
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

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Text { get; set; }
    }
}
