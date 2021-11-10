using System;

namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiBanDtoOut
    {
        public int Id { get; init; }

        public int UserId { get; init; }

        public int AdminId { get; init; }

        public DateTimeOffset StartDateTime { get; init; }

        public DateTimeOffset FinishDateTime { get; init; }

        public string IP { get; init; }

        public string Reason { get; init; }

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
