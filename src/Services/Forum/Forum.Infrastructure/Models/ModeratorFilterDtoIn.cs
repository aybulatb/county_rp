using System.Collections.Generic;

namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class ModeratorFilterDtoIn : PagedFilter
    {
        public IEnumerable<int> Ids { get; }

        public int? EntityId { get; }

        public int? EntityType { get; }

        public int? ForumId { get; }

        public ModeratorFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            int? entityId,
            int? entityType,
            int? forumId
        )
            : base(count, page)
        {
            Ids = ids;
            EntityId = entityId;
            EntityType = entityType;
            ForumId = forumId;
        }
    }
}
