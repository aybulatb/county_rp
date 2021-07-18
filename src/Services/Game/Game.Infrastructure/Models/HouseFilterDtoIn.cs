using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class HouseFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public IEnumerable<int> OwnerIds { get; }

        public IEnumerable<int> GarageIds { get; }

        public HouseFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            IEnumerable<int> ownerIds,
            IEnumerable<int> garageIds
        )
            : base(count, page)
        {
            Ids = ids;
            OwnerIds = ownerIds;
            GarageIds = garageIds;
        }
    }
}
