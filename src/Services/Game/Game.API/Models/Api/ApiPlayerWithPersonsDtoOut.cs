using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiPlayerWithPersonsDtoOut
    {
        public int Id { get; init; }

        public string Login { get; init; }

        public string Password { get; init; }

        public DateTimeOffset RegistrationDate { get; init; }

        public DateTimeOffset LastVisitDate { get; init; }

        public IEnumerable<ApiPersonDtoOut> Persons { get; init; }

        public ApiPlayerWithPersonsDtoOut(
            int id,
            string login,
            string password,
            DateTimeOffset registrationDate,
            DateTimeOffset lastVisitDate,
            IEnumerable<ApiPersonDtoOut> persons
        )
        {
            Id = id;
            Login = login;
            Password = password;
            RegistrationDate = registrationDate;
            LastVisitDate = lastVisitDate;
            Persons = persons;
        }
    }
}
