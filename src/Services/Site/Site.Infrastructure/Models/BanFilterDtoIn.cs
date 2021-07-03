using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public class BanFilterDtoIn : PagedFilter
    {
        public DateTimeOffset? StartDateTime { get; }

        public DateTimeOffset? FinishDateTime { get; }

        public BanFilterDtoIn(
            int count,
            int page,
            DateTimeOffset? startDateTime,
            DateTimeOffset? finishDateTime
        )
            : base(count, page)
        {
            StartDateTime = startDateTime;
            FinishDateTime = finishDateTime;
        }
    }
}
