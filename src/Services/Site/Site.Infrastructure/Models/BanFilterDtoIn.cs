using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record BanFilterDtoIn(
        int? Count,
        int? Page,
        DateTimeOffset? StartDateTime,
        DateTimeOffset? FinishDateTime
    ) : PagedFilter(Count, Page);
}
