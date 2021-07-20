using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiRoomFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }

        public string Name { get; set; }

        public string NameLike { get; set; }

        public IEnumerable<int> GangIds { get; set; }

        public DateTimeOffset? StartLastPaymentDate { get; set; }

        public DateTimeOffset? FinishLastPaymentDate { get; set; }
    }
}
