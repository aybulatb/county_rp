using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models
{
    public record ForumPagedFilterResultDtoOut<T>(
         int AllCount,
         int Page,
         int MaxPages,
         IEnumerable<T> Items
     );
}
