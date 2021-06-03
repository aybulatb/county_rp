using System;

namespace CountyRP.Services.Logs.Models.Api
{
    public class ApiLogUnitDtoIn
    {
        /// <summary>
        /// Время создания
        /// </summary>
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Действие
        /// </summary>
        public ApiLogActionDto ActionId { get; set; }

        /// <summary>
        /// Текст с комментарием
        /// </summary>
        public string Text { get; set; }
    }
}
