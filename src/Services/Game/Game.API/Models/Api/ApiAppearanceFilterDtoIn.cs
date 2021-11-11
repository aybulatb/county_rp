using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiAppearanceFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }
    }
}
