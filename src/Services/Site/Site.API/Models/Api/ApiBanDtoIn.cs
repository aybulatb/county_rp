using System;

namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiBanDtoIn
    {
        public int UserId { get; init; }

        public int AdminId { get; init; }

        public DateTimeOffset StartDateTime { get; init; }

        public DateTimeOffset FinishDateTime { get; init; }

        public string IP { get; init; }

        public string Reason { get; init; }

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
