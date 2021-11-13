namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public record SitePagedFilterDtoIn(
        int? Count,
        int? Page
    );
}
