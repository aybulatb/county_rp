using System;

namespace CountyRP.Services.Site.API.Models.Api
{
    public class ApiBanFilterDtoIn : ApiPagedFilter
    {
        public DateTimeOffset? StartDateTime { get; set; }

        public DateTimeOffset? FinishDateTime { get; set; }
    }
}
