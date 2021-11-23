namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class ModeratorFilterDtoIn : PagedFilter
    {
        public int? EntityId { get; }

        public int? EntityType { get; }

        public int? ForumId { get; }

        public ModeratorFilterDtoIn(
            int count,
            int page,
            int? entityId,
            int? entityType,
            int? forumId
        )
            : base(count, page)
        {
            EntityId = entityId;
            EntityType = entityType;
            ForumId = forumId;
        }
    }
}
