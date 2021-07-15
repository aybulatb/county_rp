using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiPlayerFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }

        public IEnumerable<string> Logins { get; set; }

        public DateTimeOffset? StartRegistrationDate { get; set; }

        public DateTimeOffset? FinishRegistrationDate { get; set; }

        public DateTimeOffset? StartLastVisitDate { get; set; }

        public DateTimeOffset? FinishLastVisitDate { get; set; }
    }
}
