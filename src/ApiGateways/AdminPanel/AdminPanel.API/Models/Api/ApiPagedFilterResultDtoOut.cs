using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiPagedFilterResultDtoOut<T>
    {
        public int AllCount { get; init; }

        public int Page { get; init; }

        public int MaxPages { get; init; }

        public IEnumerable<T> Items { get; init; }

        public ApiPagedFilterResultDtoOut(
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
