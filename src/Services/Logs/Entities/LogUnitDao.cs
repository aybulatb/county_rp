using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Logs.Entities
{
    public class LogUnitDao
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        /// <summary>
        /// Время создания
        /// </summary>
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [MaxLength(32)]
        public string Login { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        [MaxLength(16)]
        public string IP { get; set; }

        /// <summary>
        /// Действие
        /// </summary>
        public LogActionDao ActionId { get; set; }

        /// <summary>
        /// Текст с комментарием
        /// </summary>
        [MaxLength(128)]
        public string Text { get; set; }

        /// <summary>
        /// Конструктор для EF
        /// </summary>
        public LogUnitDao()
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public LogUnitDao(
            DateTimeOffset dateTime,
            string login,
            string ip,
            LogActionDao actionId,
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
