using System.Collections.Generic;

namespace CountyRP.Services.Site.Models.Api
{
    public class ApiPagedFilterResult<T>
    {
        public int AllCount { get; }

        public int MaxPages { get; }

        public IEnumerable<T> Items { get; }

        public ApiPagedFilterResult(
            int allCount,
            int maxPages,
            IEnumerable<T> items
        )
        {
            AllCount = allCount;
            MaxPages = maxPages;
            Items = items;
        }
    }
}
