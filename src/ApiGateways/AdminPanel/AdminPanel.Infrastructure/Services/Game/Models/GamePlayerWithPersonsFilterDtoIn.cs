using System;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public record GamePlayerWithPersonsFilterDtoIn(
        int? Count,
        int? Page,
        IEnumerable<int> Ids,
        IEnumerable<string> Logins,
        string PartOfLogin,
        DateTimeOffset? StartRegistrationDate,
        DateTimeOffset? FinishRegistrationDate ,
        DateTimeOffset? StartLastVisitDate,
        DateTimeOffset? FinishLastVisitDate,
        IEnumerable<int> PersonsIds,
        IEnumerable<string> PersonsNames,
        string PersonNameLike,
        IEnumerable<string> AdminLevelIds,
        IEnumerable<string> FactionIds
    ) : GamePagedFilterDtoIn(Count, Page);
}
