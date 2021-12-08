using System.Collections.Generic;

namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiGroupFilterDtoIn : ApiPagedFilter
    {
        public IEnumerable<int> Ids { get; init; }

        public string Name { get; init; }
    }
}
