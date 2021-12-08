using System.Collections.Generic;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record GroupFilterDtoIn(
        int? Count,
        int? Page,
        IEnumerable<int> Ids,
        string Name
    ) : PagedFilter(Count, Page);
}
