using System;

namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiSupportRequestMessageDtoIn
    {
        /// <summary>
        /// Идентификатор темы.
        /// </summary>
        public int TopicId { get; init; }

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        public string Text { get; init; }

        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int UserId { get; init; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTimeOffset CreationDate { get; init; }

        /// <summary>
        /// Дата последнего изменения.
        /// </summary>
        public DateTimeOffset EditionDate { get; init; }
    }
}
