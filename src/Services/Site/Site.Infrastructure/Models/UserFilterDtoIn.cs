﻿using System;
using System.Collections.Generic;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record UserFilterDtoIn(
        int? Count,
        int? Page,
        string Login,
        string LoginLike,
        IEnumerable<string> GroupIds,
        IEnumerable<int> PlayerIds,
        DateTimeOffset? StartRegistrationDate,
        DateTimeOffset? FinishRegistrationDate,
        DateTimeOffset? StartLastVisitDate,
        DateTimeOffset? FinishLastVisitDate
    ) : PagedFilter(Count, Page);
}
