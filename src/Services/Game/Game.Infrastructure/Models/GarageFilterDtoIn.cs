using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class GarageFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public GarageFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids
        )
            : base(count, page)
        {
            Ids = ids;
        }
    }
}
