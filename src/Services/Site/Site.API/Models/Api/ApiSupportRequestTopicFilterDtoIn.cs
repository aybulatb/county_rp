namespace CountyRP.Services.Site.API.Models.Api
{
    public class ApiSupportRequestTopicFilterDtoIn : ApiPagedFilter
    {
        /// <summary>
        /// Тип.
        /// </summary>
        public ApiSupportRequestTopicTypeDto? Type { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public ApiSupportRequestTopicStatusDto? Status { get; set; }

        /// <summary>
        /// Идентификатор пользователя-создателя.
        /// </summary>
        public int? CreatorUserId { get; set; }

        /// <summary>
        /// Идентификатор ссылочного пользователя.
        /// </summary>
        public int? RefUserId { get; set; }
    }
}
