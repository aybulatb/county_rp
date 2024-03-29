﻿using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiPlayerDtoOut
    {
        public int Id { get; init; }

        public string Login { get; init; }

        public string Password { get; init; }

        public DateTimeOffset RegistrationDate { get; init; }

        public DateTimeOffset LastVisitDate { get; init; }

        public ApiPlayerDtoOut(
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
