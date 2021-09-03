using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public class GamePagedFilterResultDtoOut<T>
    {
        public int AllCount { get; }

        public int Page { get; }

        public int MaxPages { get; }

        public IEnumerable<T> Items { get; }

        public GamePagedFilterResultDtoOut(
            int allCount,
            int page,
            int maxPages,
            IEnumerable<T> items
        )
        {
            AllCount = allCount;
            Page = page;
            MaxPages = maxPages;
            Items = items;
        }
    }
}
