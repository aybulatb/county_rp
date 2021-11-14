using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiLogUnitDtoOut
    {
        public int Id { get; init; }

        public DateTimeOffset DateTime { get; init; }

        public string Login { get; init; }

        public string IP { get; init; }

        public ApiLogActionTypeDto ActionType { get; init; }

        public string Text { get; init; }

        public ApiLogUnitDtoOut(
            int id,
            DateTimeOffset dateTime,
            string login,
            string ip,
            ApiLogActionTypeDto actionType,
            string text
        )
        {
            Id = id;
            DateTime = dateTime;
            Login = login;
            IP = ip;
            ActionType = actionType;
            Text = text;
        }
    }
}
