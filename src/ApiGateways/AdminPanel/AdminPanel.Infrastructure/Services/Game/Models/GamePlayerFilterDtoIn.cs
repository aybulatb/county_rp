using System;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public record GamePlayerFilterDtoIn(
        int? Count,
        int? Page,
        IEnumerable<int> Ids,
        IEnumerable<string> Logins,
        DateTimeOffset? StartRegistrationDate,
        DateTimeOffset? FinishRegistrationDate,
        DateTimeOffset? StartLastVisitDate,
        DateTimeOffset? FinishLastVisitDate
    );
}
