using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiPersonFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }

        public IEnumerable<string> Names { get; set; }

        public IEnumerable<int> PlayerIds { get; set; }

        public DateTimeOffset? StartRegistrationDate { get; set; }

        public DateTimeOffset? FinishRegistrationDate { get; set; }

        public DateTimeOffset? StartLastVisitDate { get; set; }

        public DateTimeOffset? FinishLastVisitDate { get; set; }

        public IEnumerable<string> AdminLevelIds { get; set; }

        public IEnumerable<string> FactionIds { get; set; }

        public IEnumerable<int> GangIds { get; set; }

        public bool? Leader { get; set; }

        public int? Rank { get; set; }
    }
}
