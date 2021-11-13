namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public record GamePagedFilterDtoIn(
        int? Count,
        int? Page
    );
}
