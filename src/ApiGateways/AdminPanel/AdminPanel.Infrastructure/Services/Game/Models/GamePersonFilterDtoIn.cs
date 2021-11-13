using System;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public record GamePersonFilterDtoIn(
        int? Count,
        int? Page,
        IEnumerable<int> Ids,
        IEnumerable<string> Names,
        string NameLike,
        IEnumerable<int> PlayerIds,
        DateTimeOffset? StartRegistrationDate,
        DateTimeOffset? FinishRegistrationDate,
        DateTimeOffset? StartLastVisitDate,
        DateTimeOffset? FinishLastVisitDate,
        IEnumerable<string> AdminLevelIds,
        IEnumerable<string> FactionIds,
        IEnumerable<int> GangIds,
        bool? Leader,
        int? Rank
    );
}
