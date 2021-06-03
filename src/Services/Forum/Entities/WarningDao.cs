using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class WarningDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int AdminId { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public DateTimeOffset FinishDateTime { get; set; }

        public int Action { get; set; }

        [MaxLength(128)]
        public string Text { get; set; }

        /// <summary>
        /// Конструктор для EF
        /// </summary>
        public WarningDao()
        {
        }

        public WarningDao(
            int id,
            int userId,
            int adminId,
            DateTimeOffset dateTime,
            DateTimeOffset finishDateTime,
            int action,
            string text
        )
        {
            Id = id;
            UserId = userId;
            AdminId = adminId;
            DateTime = dateTime;
            FinishDateTime = finishDateTime;
            Action = action;
            Text = text;
        }
    }
}
