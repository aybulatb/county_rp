using System;

namespace CountyRP.Services.Logs.Models.Api
{
    public class ApiLogUnitDtoOut
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; }

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
        public ApiLogActionDto ActionId { get; }

        /// <summary>
        /// Текст с комментарием
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ApiLogUnitDtoOut(
            int id,
            DateTimeOffset dateTime,
            string login,
            string ip,
            ApiLogActionDto actionId,
            string text
        )
        {
            Id = id;
            DateTime = dateTime;
            Login = login;
            IP = ip;
            ActionId = actionId;
            Text = text;
        }
    }
}
