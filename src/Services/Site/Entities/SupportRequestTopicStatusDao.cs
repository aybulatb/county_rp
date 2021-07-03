namespace CountyRP.Services.Site.Entities
{
    public enum SupportRequestTopicStatusDao
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
