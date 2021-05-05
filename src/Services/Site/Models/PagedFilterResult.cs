using System.Collections.Generic;

namespace CountyRP.Services.Site.Models
{
    public class PagedFilterResult<T>
    {
        public int AllCount { get; }

        public int MaxPages { get; }

        public IEnumerable<T> Items { get; }

        public PagedFilterResult(
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
