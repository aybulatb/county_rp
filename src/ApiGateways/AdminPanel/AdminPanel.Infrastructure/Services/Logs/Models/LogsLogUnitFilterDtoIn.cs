using System;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models
{
    public record LogsLogUnitFilterDtoIn(
        int? Count,
        int? Page,
        IEnumerable<int> Ids,
        DateTimeOffset? StartDateTime,
        DateTimeOffset? FinishDateTime,
        string Login,
        string IP,
        LogsLogActionTypeDto? ActionType,
        string Text
    ) : LogsPagedFilterDtoIn(Count, Page);
}
