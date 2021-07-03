namespace CountyRP.Services.Site.Infrastructure.Models
{
    public enum SupportRequestTopicTypeDto
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
