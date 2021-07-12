using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Infrastructure.Entities
{
    public class ReputationDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ChangedByUserId { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public int Action { get; set; }

        [MaxLength(128)]
        public string Text { get; set; }

        /// <summary>
        /// Конструктор для EF
        /// </summary>
        public ReputationDao()
        {
        }

        public ReputationDao(
            int id,
            int userId,
            int changedByUserId,
            DateTimeOffset dateTime,
            int action,
            string text
        )
        {
            Id = id;
            UserId = userId;
            ChangedByUserId = changedByUserId;
            DateTime = dateTime;
            Action = action;
            Text = text;
        }
    }
}
