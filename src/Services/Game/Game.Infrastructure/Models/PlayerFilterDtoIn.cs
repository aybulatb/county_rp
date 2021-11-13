using System;
using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class PlayerFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public IEnumerable<string> Logins { get; }

        public string PartOfLogin { get; }

        public DateTimeOffset? StartRegistrationDate { get; }

        public DateTimeOffset? FinishRegistrationDate { get; }

        public DateTimeOffset? StartLastVisitDate { get; }

        public DateTimeOffset? FinishLastVisitDate { get; }

        public PlayerFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            IEnumerable<string> logins,
            string partOfLogin,
            DateTimeOffset? startRegistrationDate,
            DateTimeOffset? finishRegistrationDate,
            DateTimeOffset? startLastVisitDate,
            DateTimeOffset? finishLastVisitDate
        )
            : base(count, page)
        {
            Ids = ids;
            Logins = logins;
            PartOfLogin = partOfLogin;
            StartRegistrationDate = startRegistrationDate;
            FinishRegistrationDate = finishRegistrationDate;
            StartLastVisitDate = startLastVisitDate;
            FinishLastVisitDate = finishLastVisitDate;
        }
    }
}
