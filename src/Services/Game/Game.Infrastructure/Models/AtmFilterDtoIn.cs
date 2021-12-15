using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public record AtmFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public IEnumerable<int> BusinessIds { get; }

        public AtmFilterDtoIn(
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
