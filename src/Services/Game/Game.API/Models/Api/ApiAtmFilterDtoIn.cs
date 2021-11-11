using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiAtmFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public IEnumerable<int> BusinessIds { get; init; }
    }
}
