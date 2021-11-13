namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiPagedFilterDtoIn
    {
        public int Count { get; init; }

        public int Page { get; init; }
    }
}
