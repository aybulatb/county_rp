using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public record SiteGroupFilterDtoIn(
        int? Count,
        int? Page,
        IEnumerable<int> Ids,
        string Name
    ) : SitePagedFilterDtoIn(Count, Page);
}
