using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models
{
    public record LogsPagedFilterResultDtoOut<T>(
        int AllCount,
        int Page,
        int MaxPages,
        IEnumerable<T> Items
    );
}
