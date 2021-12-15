namespace CountyRP.Services.Game.Infrastructure.Models
{
    public record PagedFilterDtoIn(
        int? Count,
        int? Page
    );
}
