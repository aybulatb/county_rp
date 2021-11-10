using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record BanDtoOut(
        int Id,
        int UserId,
        int AdminId,
        DateTimeOffset StartDateTime,
        DateTimeOffset FinishDateTime,
        string IP,
        string Reason
    );
}
