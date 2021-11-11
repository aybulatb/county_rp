using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiPlayerWithPersonsFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public IEnumerable<string> Logins { get; init; }

        public DateTimeOffset? StartRegistrationDate { get; init; }

        public DateTimeOffset? FinishRegistrationDate { get; init; }

        public DateTimeOffset? StartLastVisitDate { get; init; }

        public DateTimeOffset? FinishLastVisitDate { get; init; }

        public IEnumerable<int> PersonsIds { get; init; }

        public IEnumerable<string> PersonsNames { get; init; }

        public string PersonNameLike { get; init; }

        public IEnumerable<string> AdminLevelIds { get; set; }

        public IEnumerable<string> FactionIds { get; set; }
    }
}
