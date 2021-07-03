namespace CountyRP.Services.Site.Infrastructure.Models
{
    public enum SupportRequestTopicStatusDto
    {
        /// <summary>
        /// Неизвестный.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Новое.
        /// </summary>
        New = 1,

        /// <summary>
        /// Закрытое.
        /// </summary>
        Closed = 2,

        /// <summary>
        /// На рассмотрении.
        /// </summary>
        Consideration = 3,
    }
}
