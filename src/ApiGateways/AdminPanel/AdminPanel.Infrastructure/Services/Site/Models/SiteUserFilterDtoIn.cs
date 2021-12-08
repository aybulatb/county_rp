using System;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public record SiteUserFilterDtoIn(
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
    );
}
