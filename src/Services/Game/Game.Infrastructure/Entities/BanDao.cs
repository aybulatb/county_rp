using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class BanDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// ID забанненого игрока.
        /// </summary>
        public int? PlayerId { get; set; }

        /// <summary>
        /// ID забанненого персонажа.
        /// </summary>
        public int? PersonId { get; set; }

        /// <summary>
        /// ID забанившего администратора.
        /// </summary>
        public int AdminId { get; set; }

        public DateTimeOffset StartDateTime { get; set; }

        public DateTimeOffset FinishDateTime { get; set; }

        /// <summary>
        /// IP забаненного пользователя.
        /// </summary>
        [MaxLength(16)]
        public string IP { get; set; }

        [MaxLength(256)]
        public string Reason { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        internal BanDao()
        {
        }

        public BanDao(
            int id,
            int? playerId,
            int? personId,
            int adminId,
            DateTimeOffset startDateTime,
            DateTimeOffset finishDateTime,
            string ip,
            string reason
        )
        {
            Id = id;
            PlayerId = playerId;
            PersonId = personId;
            AdminId = adminId;
            StartDateTime = startDateTime;
            FinishDateTime = finishDateTime;
            IP = ip;
            Reason = reason;
        }
    }
}
