using System.Collections.Generic;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record SupportRequestMessageFilterDtoIn(
        int? Count,
        int? Page,
        IList<int> Ids,
        int? TopicId,
        int? UserId
    ) : PagedFilter(Count, Page);
}
