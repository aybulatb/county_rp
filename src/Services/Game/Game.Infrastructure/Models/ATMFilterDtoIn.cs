using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class ATMFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public IEnumerable<int> BusinessIds { get; }

        public ATMFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            IEnumerable<int> businessIds
        )
            : base(count, page)
        {
            Ids = ids;
            BusinessIds = businessIds;
        }
    }
}
