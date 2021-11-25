using System.Collections.Generic;

namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class ForumFilterDtoIn : PagedFilter
    {
        public IEnumerable<int> Ids { get; }

        public IEnumerable<int> ParentIds { get; }

        public ForumFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            IEnumerable<int> parentIds
        )
            : base(count, page)
        {
            Ids = ids;
            ParentIds = parentIds;
        }
    }
}
