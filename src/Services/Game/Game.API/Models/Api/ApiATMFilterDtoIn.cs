using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiATMFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }

        public IEnumerable<int> BusinessIds { get; set; }
    }
}
