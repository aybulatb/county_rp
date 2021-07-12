using System;

namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class WarningDtoOut
    {
        public int Id { get; }

        public int UserId { get; }

        public int AdminId { get; }

        public DateTimeOffset DateTime { get; }

        public DateTimeOffset FinishDateTime { get; }

        public int Action { get; }

        public string Text { get; }

        public WarningDtoOut(
            int id,
            int userId,
            int adminId,
            DateTimeOffset dateTime,
            DateTimeOffset finishDateTime,
            int action,
            string text
        )
        {
            Id = id;
            UserId = userId;
            AdminId = adminId;
            DateTime = dateTime;
            FinishDateTime = finishDateTime;
            Action = action;
            Text = text;
        }
    }
}
