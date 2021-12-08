using System;
using System.Collections.Generic;

namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiUserFilterDtoIn : ApiPagedFilter
    {
        public IEnumerable<int> Ids { get; init; }

        public string Login { get; init; }

        public string LoginLike { get; init; }

        public IEnumerable<int> GroupIds { get; init; }

        public IEnumerable<int> PlayerIds { get; init; }

        public DateTimeOffset? StartRegistrationDate { get; init; }

        public DateTimeOffset? FinishRegistrationDate { get; init; }

        public DateTimeOffset? StartLastVisitDate { get; init; }

        public DateTimeOffset? FinishLastVisitDate { get; init; }
    }
}
