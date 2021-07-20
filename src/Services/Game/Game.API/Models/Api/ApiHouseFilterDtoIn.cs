using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiHouseFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }

        public IEnumerable<int> OwnerIds { get; set; }

        public IEnumerable<int> GarageIds { get; set; }
    }
}
