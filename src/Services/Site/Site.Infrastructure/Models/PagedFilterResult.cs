using System.Collections.Generic;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record PagedFilterResult<T>(
        int AllCount,
        int Page,
        int MaxPages,
        IEnumerable<T> Items
    );
}
