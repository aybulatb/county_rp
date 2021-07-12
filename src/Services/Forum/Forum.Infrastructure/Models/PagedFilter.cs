namespace CountyRP.Services.Forum.Infrastructure.Models
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
