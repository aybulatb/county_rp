namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiGroupFilterDtoIn : ApiPagedFilter
    {
        public string Name { get; init; }
    }
}
