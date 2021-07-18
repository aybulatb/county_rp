using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class RoomFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public string Name { get; }

        public string NameLike { get; }

        public IEnumerable<int> GangIds { get; }

        public DateTimeOffset? StartLastPaymentDate { get; }

        public DateTimeOffset? FinishLastPaymentDate { get; }

        public RoomFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            string name,
            string nameLike,
            IEnumerable<int> gangIds,
            DateTimeOffset? startLastPaymentDate,
            DateTimeOffset? finishLastPaymentDate
        )
            : base(count, page)
        {
            Ids = ids;
            Name = name;
            NameLike = nameLike;
            GangIds = gangIds;
            StartLastPaymentDate = startLastPaymentDate;
            FinishLastPaymentDate = finishLastPaymentDate;
        }
    }
}
