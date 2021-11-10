namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record GroupFilterDtoIn(
        int? Count,
        int? Page,
        string Name
    ) : PagedFilter(Count, Page);
}
