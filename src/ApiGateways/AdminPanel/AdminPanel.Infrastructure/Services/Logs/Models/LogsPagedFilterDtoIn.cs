namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Models
{
    public record LogsPagedFilterDtoIn(
        int? Count,
        int? Page
    );
}
