using System;
using System.Collections.Generic;

namespace CountyRP.Services.Logs.API.Models.Api
{
    public class ApiLogUnitFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IList<int> Ids { get; set; }

        public DateTimeOffset? StartDateTime { get; set; }

        public DateTimeOffset? FinishDateTime { get; set; }

        public string Login { get; set; }

        public string IP { get; set; }

        public ApiLogActionDto? ActionId { get; set; }

        public string Text { get; set; }
    }
}
