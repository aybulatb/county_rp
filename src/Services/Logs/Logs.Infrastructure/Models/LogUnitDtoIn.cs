using System;

namespace CountyRP.Services.Logs.Infrastructure.Models
{
    public class LogUnitDtoIn
    {
        /// <summary>
        /// Время создания
        /// </summary>
        public DateTimeOffset DateTime { get; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; }

        /// <summary>
        /// Действие
        /// </summary>
        public LogActionDto ActionId { get; }

        /// <summary>
        /// Текст с комментарием
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public LogUnitDtoIn(
            DateTimeOffset dateTime,
            string login,
            string ip,
            LogActionDto actionId,
            string text
        )
        {
            DateTime = dateTime;
            Login = login;
            IP = ip;
            ActionId = actionId;
            Text = text;
        }
    }
}
