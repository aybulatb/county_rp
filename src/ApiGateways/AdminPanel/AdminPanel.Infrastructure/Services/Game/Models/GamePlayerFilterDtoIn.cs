using System;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public class GamePlayerFilterDtoIn
    {
        public int? Count { get; }
        
        public int? Page { get; }

        public IEnumerable<int> Ids { get; }

        public IEnumerable<string> Logins { get; }

        public DateTimeOffset? StartRegistrationDate { get; }

        public DateTimeOffset? FinishRegistrationDate { get; }

        public DateTimeOffset? StartLastVisitDate { get; }

        public DateTimeOffset? FinishLastVisitDate { get; }

        public GamePlayerFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            IEnumerable<string> logins,
            DateTimeOffset? startRegistrationDate,
            DateTimeOffset? finishRegistrationDate,
            DateTimeOffset? startLastVisitDate,
            DateTimeOffset? finishLastVisitDate
        )
        {
            Count = count;
            Page = page;
            Ids = ids;
            Logins = logins;
            StartRegistrationDate = startRegistrationDate;
            FinishRegistrationDate = finishRegistrationDate;
            StartLastVisitDate = startLastVisitDate;
            FinishLastVisitDate = finishLastVisitDate;
        }
    }
}
