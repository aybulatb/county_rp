using System;

namespace CountyRP.Services.Logs.Models.Api
{
    public class ApiLogUnitFilterDtoIn : ApiPagedFilterDtoIn
    {
        public DateTimeOffset? StartDateTime { get; set; }

        public DateTimeOffset? FinishDateTime { get; set; }

        public string Login { get; set; }

        public string IP { get; set; }

        public ApiLogActionDto? ActionId { get; set; }

        public string Text { get; set; }
    }
}
