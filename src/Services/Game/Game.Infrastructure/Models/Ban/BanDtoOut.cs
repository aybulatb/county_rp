using System;

namespace CountyRP.Services.Game.Infrastructure.Infrastructure.Models.Ban
{
    public record BanDtoOut(
        int Id,
        int? PlayerId,
        int? PersonId,
        int AdminId,
        DateTimeOffset StartDateTime,
        DateTimeOffset FinishDateTime,
        string IP,
        string Reason
    );
}
