using System;
using System.Collections.Generic;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record UserFilterDtoIn(
        int? Count,
        int? Page,
        IEnumerable<int> Ids,
        string Login,
        string LoginLike,
        IEnumerable<int> GroupIds,
        IEnumerable<int> PlayerIds,
        DateTimeOffset? StartRegistrationDate,
        DateTimeOffset? FinishRegistrationDate,
        DateTimeOffset? StartLastVisitDate,
        DateTimeOffset? FinishLastVisitDate
    ) : PagedFilter(Count, Page);
}
