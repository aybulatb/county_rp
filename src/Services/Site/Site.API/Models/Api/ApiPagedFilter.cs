namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiPagedFilter
    {
        public int? Count { get; init; }

        public int? Page { get; init; }
    }
}
