using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class TeleportFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public string Name { get; }

        public string NameLike { get; }

        public IEnumerable<string> FactionIds { get; }

        public IEnumerable<int> GangIds { get; }

        public IEnumerable<int> RoomIds { get; }

        public IEnumerable<int> BusinessIds { get; }

        public TeleportFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            string name,
            string nameLike,
            IEnumerable<string> factionIds,
            IEnumerable<int> gangIds,
            IEnumerable<int> roomIds,
            IEnumerable<int> businessIds
        )
            : base(count, page)
        {
            Ids = ids;
            Name = name;
            NameLike = nameLike;
            FactionIds = factionIds;
            GangIds = gangIds;
            RoomIds = roomIds;
            BusinessIds = businessIds;
        }
    }
}
