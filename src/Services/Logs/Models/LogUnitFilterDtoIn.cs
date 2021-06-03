using System;

namespace CountyRP.Services.Logs.Models
{
    public class LogUnitFilterDtoIn : PagedFilterDtoIn
    {
        public DateTimeOffset? StartDateTime { get; }

        public DateTimeOffset? FinishDateTime { get; }

        public string Login { get; }

        public string IP { get; }

        public LogActionDto? ActionId { get; }

        public string Text { get; }

        public LogUnitFilterDtoIn(
            int count,
            int page,
            DateTimeOffset? startDateTime,
            DateTimeOffset? finishDateTime,
            string login,
            string ip,
            LogActionDto? actionId,
            string text
        )
            : base(count, page)
        {
            StartDateTime = startDateTime;
            FinishDateTime = finishDateTime;
            Login = login;
            IP = ip;
            ActionId = actionId;
            Text = text;
        }
    }
}
