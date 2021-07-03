namespace CountyRP.Services.Site.Infrastructure.Entities
{
    public enum SupportRequestTopicTypeDao
    {
        /// <summary>
        /// Неизвестный.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Жалоба.
        /// </summary>
        Report = 1,

        /// <summary>
        /// Жалоба на администратора.
        /// </summary>
        ReportOnAdmin = 2,

        /// <summary>
        /// Разбан.
        /// </summary>
        Unban = 3,
    }
}
