using System;

namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiBanFilterDtoIn : ApiPagedFilter
    {
        public DateTimeOffset? StartDateTime { get; init; }

        public DateTimeOffset? FinishDateTime { get; init; }
    }
}
