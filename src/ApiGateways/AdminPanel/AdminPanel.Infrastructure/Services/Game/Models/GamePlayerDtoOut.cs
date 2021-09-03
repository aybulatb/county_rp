using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public class GamePlayerDtoOut
    {
        public int Id { get; }

        public string Login { get; }

        public string Password { get; }

        public DateTimeOffset RegistrationDate { get; }

        public DateTimeOffset LastVisitDate { get; }

        public GamePlayerDtoOut(
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
