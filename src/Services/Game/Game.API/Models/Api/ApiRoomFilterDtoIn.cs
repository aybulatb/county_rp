using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiRoomFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public string Name { get; init; }

        public string NameLike { get; init; }

        public IEnumerable<int> GangIds { get; init; }

        public DateTimeOffset? StartLastPaymentDate { get; init; }

        public DateTimeOffset? FinishLastPaymentDate { get; init; }
    }
}
