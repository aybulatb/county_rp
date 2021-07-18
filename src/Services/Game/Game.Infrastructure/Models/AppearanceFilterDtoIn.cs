using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class AppearanceFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public AppearanceFilterDtoIn(
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
