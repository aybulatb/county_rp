namespace CountyRP.Services.Logs.Infrastructure.Models
{
    public class PagedFilterDtoIn
    {
        public int Count { get; }

        public int Page { get; }

        public PagedFilterDtoIn(
            int count,
            int page
        )
        {
            Count = count;
            Page = page;
        }
    }
}
