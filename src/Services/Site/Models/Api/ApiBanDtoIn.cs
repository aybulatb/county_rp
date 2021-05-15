using System;

namespace CountyRP.Services.Site.Models.Api
{
    public class ApiBanDtoIn
    {
        public int UserId { get; set; }

        public int AdminId { get; set; }

        public DateTimeOffset StartDateTime { get; set; }

        public DateTimeOffset FinishDateTime { get; set; }

        public string IP { get; set; }

        public string Reason { get; set; }

        public ApiBanDtoIn(
            int userId,
            int adminId,
            DateTimeOffset startDateTime,
            DateTimeOffset finishDateTime,
            string ip,
            string reason
        )
        {
            UserId = userId;
            AdminId = adminId;
            StartDateTime = startDateTime;
            FinishDateTime = finishDateTime;
            IP = ip;
            Reason = reason;
        }
    }
}
