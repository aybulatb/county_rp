using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public record SitePagedFilterResultDtoOut<T>(
        int AllCount,
        int Page,
        int MaxPages,
        IEnumerable<T> Items
    );
}
