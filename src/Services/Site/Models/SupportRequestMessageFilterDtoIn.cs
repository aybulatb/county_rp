using System.Collections.Generic;

namespace CountyRP.Services.Site.Models
{
    public class SupportRequestMessageFilterDtoIn : PagedFilter
    {
        public IList<int> Ids { get; }

        public int? TopicId { get; }

        public int? UserId { get; }

        public SupportRequestMessageFilterDtoIn(
            int count,
            int page,
            IList<int> ids,
            int? topicId,
            int? userId
        )
            : base(count, page)
        {
            Ids = ids;
            TopicId = topicId;
            UserId = userId;
        }
    }
}
