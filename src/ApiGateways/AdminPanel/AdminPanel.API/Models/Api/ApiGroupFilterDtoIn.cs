using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiGroupFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public string Name { get; init; }
    }
}
