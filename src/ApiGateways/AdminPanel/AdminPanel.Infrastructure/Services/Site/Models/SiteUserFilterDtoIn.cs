using System;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public record SiteUserFilterDtoIn(
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
    );
}
