using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiPersonFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public IEnumerable<string> Names { get; init; }

        public string NameLike { get; init; }

        public IEnumerable<int> PlayerIds { get; init; }

        public DateTimeOffset? StartRegistrationDate { get; init; }

        public DateTimeOffset? FinishRegistrationDate { get; init; }

        public DateTimeOffset? StartLastVisitDate { get; init; }

        public DateTimeOffset? FinishLastVisitDate { get; init; }

        public IEnumerable<string> AdminLevelIds { get; init; }

        public IEnumerable<string> FactionIds { get; init; }

        public IEnumerable<int> GangIds { get; init; }

        public bool? Leader { get; init; }

        public int? Rank { get; init; }
    }
}
