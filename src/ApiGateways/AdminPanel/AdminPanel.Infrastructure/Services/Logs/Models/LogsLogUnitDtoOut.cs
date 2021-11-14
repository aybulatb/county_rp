using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models
{
    public record LogsLogUnitDtoOut(
        int Id,
        DateTimeOffset DateTime,
        string Login,
        string IP,
        LogsLogActionTypeDto ActionType,
        string Text
    );
}
