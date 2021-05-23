using System;

namespace CountyRP.Services.Forum.Models
{
    public class ReputationDtoIn
    {
        public int UserId { get; }

        public int ChangedByUserId { get; }

        public DateTimeOffset DateTime { get; }

        public int Action { get; }

        public string Text { get; }

        public ReputationDtoIn(
            int userId,
            int changedByUserId,
            DateTimeOffset dateTime,
            int action,
            string text
        )
        {
            UserId = userId;
            ChangedByUserId = changedByUserId;
            DateTime = dateTime;
            Action = action;
            Text = text;
        }
    }
}
