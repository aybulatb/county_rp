using System;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiLogUnitFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public DateTimeOffset? StartDateTime { get; init; }

        public DateTimeOffset? FinishDateTime { get; init; }

        public string Login { get; init; }

        public string IP { get; init; }

        public ApiLogActionTypeDto? ActionType { get; init; }

        public string Text { get; init; }
    }
}
