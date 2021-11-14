using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiLogUnitDtoIn
    {
        public DateTimeOffset DateTime { get; init; }

        public string Login { get; init; }

        public string IP { get; init; }

        public ApiLogActionTypeDto ActionType { get; init; }

        public string Text { get; init; }
    }
}
