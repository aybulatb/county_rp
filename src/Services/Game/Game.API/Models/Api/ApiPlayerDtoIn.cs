using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiPlayerDtoIn
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }

        public DateTimeOffset LastVisitDate { get; set; }
    }
}
