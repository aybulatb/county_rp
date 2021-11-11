using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiPlayerDtoIn
    {
        public string Login { get; init; }

        public string Password { get; init; }

        public DateTimeOffset RegistrationDate { get; init; }

        public DateTimeOffset LastVisitDate { get; init; }
    }
}
