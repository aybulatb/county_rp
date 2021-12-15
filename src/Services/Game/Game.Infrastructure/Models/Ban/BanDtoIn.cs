using System;

namespace CountyRP.Services.Game.Infrastructure.Infrastructure.Models.Ban
{
    public record BanDtoIn(
        int? PlayerId,
        int? PersonId,
        int AdminId,
        DateTimeOffset StartDateTime,
        DateTimeOffset FinishDateTime,
        string IP,
        string Reason
    );
}
