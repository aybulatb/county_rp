using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public record LockerRoomFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public IEnumerable<string> FactionIds { get; }

        public LockerRoomFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            IEnumerable<string> factionIds
        )
            : base(count, page)
        {
            Ids = ids;
            FactionIds = factionIds;
        }
    }
}
