using System;
using System.Collections.Generic;

namespace CountyRP.Services.Logs.Infrastructure.Models
{
    public class LogUnitFilterDtoIn : PagedFilterDtoIn
    {
        public IList<int> Ids { get; }

        public DateTimeOffset? StartDateTime { get; }

        public DateTimeOffset? FinishDateTime { get; }

        public string Login { get; }

        public string IP { get; }

        public LogActionDto? ActionId { get; }

        public string Text { get; }

        public LogUnitFilterDtoIn(
            int? count,
            int? page,
            IList<int> ids,
            DateTimeOffset? startDateTime,
            DateTimeOffset? finishDateTime,
            string login,
            string ip,
            LogActionDto? actionId,
            string text
        )
            : base(count, page)
        {
            Ids = ids;
            StartDateTime = startDateTime;
            FinishDateTime = finishDateTime;
            Login = login;
            IP = ip;
            ActionId = actionId;
            Text = text;
        }
    }
}
