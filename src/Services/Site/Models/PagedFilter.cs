namespace CountyRP.Services.Site.Models
{
    public class PagedFilter
    {
        public int Count { get; }

        public int Page { get; }

        public PagedFilter(
            int count,
            int page
        )
        {
            Count = count;
            Page = page;
        }
    }
}
