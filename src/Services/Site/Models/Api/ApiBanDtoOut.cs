using System;

namespace CountyRP.Services.Site.Models.Api
{
    public class ApiBanDtoOut
    {
        public int Id { get; }

        public int UserId { get; }

        public int AdminId { get; }

        public DateTimeOffset StartDateTime { get; }

        public DateTimeOffset FinishDateTime { get; }

        public string IP { get; }

        public string Reason { get; }

        public ApiBanDtoOut(
            int id,
            int userId,
            int adminId,
            DateTimeOffset startDateTime,
            DateTimeOffset finishDateTime,
            string ip,
            string reason
        )
        {
            Id = id;
            UserId = userId;
            AdminId = adminId;
            StartDateTime = startDateTime;
            FinishDateTime = finishDateTime;
            IP = ip;
            Reason = reason;
        }
    }
}
