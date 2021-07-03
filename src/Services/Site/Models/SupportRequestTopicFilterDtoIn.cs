namespace CountyRP.Services.Site.Models
{
    public class SupportRequestTopicFilterDtoIn : PagedFilter
    {
        /// <summary>
        /// Тип.
        /// </summary>
        public SupportRequestTopicTypeDto? Type { get; }

        /// <summary>
        /// Статус.
        /// </summary>
        public SupportRequestTopicStatusDto? Status { get; }

        /// <summary>
        /// Идентификатор пользователя-создателя.
        /// </summary>
        public int? CreatorUserId { get; }

        /// <summary>
        /// Идентификатор ссылочного пользователя.
        /// </summary>
        public int? RefUserId { get; }

        public SupportRequestTopicFilterDtoIn(
            int count,
            int page,
            SupportRequestTopicTypeDto? type,
            SupportRequestTopicStatusDto? status,
            int? creatorUserId,
            int? refUserId
        )
            : base(count, page)
        {
            Type = type;
            Status = status;
            CreatorUserId = creatorUserId;
            RefUserId = refUserId;
        }
    }
}
