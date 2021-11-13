using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public record GamePagedFilterResultDtoOut<T>(
        int AllCount,
        int Page,
        int MaxPages,
        IEnumerable<T> Items
    );
}
