using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiGarageFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }
    }
}
