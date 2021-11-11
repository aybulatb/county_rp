using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiHouseFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public IEnumerable<int> OwnerIds { get; init; }

        public IEnumerable<int> GarageIds { get; init; }
    }
}
