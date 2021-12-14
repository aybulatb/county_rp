using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiUpdatedFullUserDtoIn
    {
        public string Login { get; init; }

        public int GroupId { get; init; }

        public IEnumerable<ApiUpdatedFullUserPersonDtoIn> Persons { get; init; }

        public ApiUpdatedFullUserDtoIn(
            string login,
            int groupId,
            IEnumerable<ApiUpdatedFullUserPersonDtoIn> persons
        )
        {
            Login = login;
            GroupId = groupId;
            Persons = persons;
        }
    }
}
