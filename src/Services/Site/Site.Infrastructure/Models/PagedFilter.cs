namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record PagedFilter(
        int? Count,
        int? Page
    );
}
