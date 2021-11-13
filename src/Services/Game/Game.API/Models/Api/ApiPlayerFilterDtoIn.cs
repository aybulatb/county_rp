using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiPlayerFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public IEnumerable<string> Logins { get; init; }

        public string PartOfLogin { get; init; }

        public DateTimeOffset? StartRegistrationDate { get; init; }

        public DateTimeOffset? FinishRegistrationDate { get; init; }

        public DateTimeOffset? StartLastVisitDate { get; init; }

        public DateTimeOffset? FinishLastVisitDate { get; init; }
    }
}
