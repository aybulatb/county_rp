using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class PlayerDao
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        /// <summary>
        /// Логин.
        /// </summary>
        [MaxLength(32)]
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [MaxLength(64)]
        public string Password { get; set; }

        /// <summary>
        /// Дата и время регистрация.
        /// </summary>
        public DateTimeOffset RegistrationDate { get; set; }

        /// <summary>
        /// Дата и время последнего визита.
        /// </summary>
        public DateTimeOffset LastVisitDate { get; set; }

        /// <summary>
        /// Конструктор EF.
        /// </summary>
        public PlayerDao()
        {
        }

        public PlayerDao(
            int id,
            string login,
            string password,
            DateTimeOffset registrationDate,
            DateTimeOffset lastVisitDate
        )
        {
            Id = id;
            Login = login;
            Password = password;
            RegistrationDate = registrationDate;
            LastVisitDate = lastVisitDate;
        }
    }
}
