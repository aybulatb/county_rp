using CountyRP.Services.Game.Infrastructure.Models;
using System;

namespace CountyRP.Services.Game.Infrastructure.Infrastructure.Models.Ban
{
    public record BanFilterDtoIn(
        int? Count,
        int? Page,
        int? PlayerId,
        int? UserId,
        DateTimeOffset? StartDateTime,
        DateTimeOffset? FinishDateTime
    ) : PagedFilterDtoIn(Count, Page);
}
