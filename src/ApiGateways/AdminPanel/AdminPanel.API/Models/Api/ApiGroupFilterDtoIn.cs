namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiGroupFilterDtoIn : ApiPagedFilterDtoIn
    {
        public string Name { get; init; }
    }
}
