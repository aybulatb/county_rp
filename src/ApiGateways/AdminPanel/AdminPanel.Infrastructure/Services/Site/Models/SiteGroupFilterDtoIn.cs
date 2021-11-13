namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public record SiteGroupFilterDtoIn(
        int? Count,
        int? Page,
        string Name
    ) : SitePagedFilterDtoIn(Count, Page);
}
