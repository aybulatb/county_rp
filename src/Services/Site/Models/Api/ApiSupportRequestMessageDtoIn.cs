using System;

namespace CountyRP.Services.Site.Models.Api
{
    public class ApiSupportRequestMessageDtoIn
    {
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
        public DateTimeOffset EditionDate { get; set; }
    }
}
