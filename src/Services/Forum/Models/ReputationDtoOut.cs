using System;

namespace CountyRP.Services.Forum.Models
{
    public class ReputationDtoOut
    {
        public int Id { get; }

        public int UserId { get; }

        public int ChangedByUserId { get; }

        public DateTimeOffset DateTime { get; }

        public int Action { get; }

        public string Text { get; }

        public ReputationDtoOut(
            int id,
            int userId,
            int changedByUserId,
            DateTimeOffset dateTime,
            int action,
            string text
        )
        {
            Id = id;
            UserId = userId;
            ChangedByUserId = changedByUserId;
            DateTime = dateTime;
            Action = action;
            Text = text;
        }
    }
}
