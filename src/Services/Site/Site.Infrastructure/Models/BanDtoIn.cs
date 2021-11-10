using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record BanDtoIn(
        int UserId,
        int AdminId,
        DateTimeOffset StartDateTime,
        DateTimeOffset FinishDateTime,
        string IP,
        string Reason
    );
}
