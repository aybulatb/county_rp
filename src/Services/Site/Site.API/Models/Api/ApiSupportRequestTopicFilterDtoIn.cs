namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiSupportRequestTopicFilterDtoIn : ApiPagedFilter
    {
        /// <summary>
        /// Тип.
        /// </summary>
        public ApiSupportRequestTopicTypeDto? Type { get; init; }

        /// <summary>
        /// Статус.
        /// </summary>
        public ApiSupportRequestTopicStatusDto? Status { get; init; }

        /// <summary>
        /// Идентификатор пользователя-создателя.
        /// </summary>
        public int? CreatorUserId { get; init; }

        /// <summary>
        /// Идентификатор ссылочного пользователя.
        /// </summary>
        public int? RefUserId { get; init; }
    }
}
