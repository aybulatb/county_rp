using System;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiFullUserDtoOut
    {
        public int Id { get; init; }

        public string Login { get; init; }

        public DateTimeOffset RegistrationDate { get; init; }

        public DateTimeOffset LastVisitDate { get; init; }

        public string GroupId { get; init; }

        public IEnumerable<ApiFullUserPersonDtoOut> Persons { get; init; }

        public ApiFullUserDtoOut(
            int id,
            string login,
            DateTimeOffset registrationDate,
            DateTimeOffset lastVisitDate,
            string groupId,
            IEnumerable<ApiFullUserPersonDtoOut> persons
        )
        {
            Id = id;
            Login = login;
            RegistrationDate = registrationDate;
            LastVisitDate = lastVisitDate;
            GroupId = groupId;
            Persons = persons;
        }
    }
}
