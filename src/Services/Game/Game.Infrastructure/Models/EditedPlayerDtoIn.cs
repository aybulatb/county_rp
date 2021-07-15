using System;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class EditedPlayerDtoIn
    {
        public int Id { get; }

        public string Login { get; }

        public string Password { get; }

        public DateTimeOffset LastVisitDate { get; }

        public EditedPlayerDtoIn(
            int id,
            string login,
            string password,
            DateTimeOffset lastVisitDate
        )
        {
            Id = id;
            Login = login;
            Password = password;
            LastVisitDate = lastVisitDate;
        }
    }
}
