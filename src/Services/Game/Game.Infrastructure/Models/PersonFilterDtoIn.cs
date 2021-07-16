using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class PersonFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public IEnumerable<string> Names { get; }

        public IEnumerable<int> PlayerIds { get; }

        public DateTimeOffset? StartRegistrationDate { get; }

        public DateTimeOffset? FinishRegistrationDate { get; }

        public DateTimeOffset? StartLastVisitDate { get; }

        public DateTimeOffset? FinishLastVisitDate { get; }

        public IEnumerable<string> AdminLevelIds { get; }

        public IEnumerable<string> FactionIds { get; }

        public IEnumerable<int> GangIds { get; }

        public bool? Leader { get; }

        public int? Rank { get; }

        public PersonFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            IEnumerable<string> names,
            IEnumerable<int> playerIds,
            DateTimeOffset? startRegistrationDate,
            DateTimeOffset? finishRegistrationDate,
            DateTimeOffset? startLastVisitDate,
            DateTimeOffset? finishLastVisitDate,
            IEnumerable<string> adminLevelIds,
            IEnumerable<string> factionIds,
            IEnumerable<int> gangIds,
            bool? leader,
            int? rank
        )
            : base(count, page)
        {
            Ids = ids;
            Names = names;
            PlayerIds = playerIds;
            StartRegistrationDate = startRegistrationDate;
            FinishRegistrationDate = finishRegistrationDate;
            StartLastVisitDate = startLastVisitDate;
            FinishLastVisitDate = finishLastVisitDate;
            AdminLevelIds = adminLevelIds;
            FactionIds = factionIds;
            GangIds = gangIds;
            Leader = leader;
            Rank = rank;
        }
    }
}
