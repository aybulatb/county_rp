using System;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class PlayerDtoIn
    {
        public string Login { get; }

        public string Password { get; }

        public DateTimeOffset RegistrationDate { get; }

        public DateTimeOffset LastVisitDate { get; }

        public PlayerDtoIn(
            string login,
            string password,
            DateTimeOffset registrationDate,
            DateTimeOffset lastVisitDate
        )
        {
            Login = login;
            Password = password;
            RegistrationDate = registrationDate;
            LastVisitDate = lastVisitDate;
        }
    }
}
