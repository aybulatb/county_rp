using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiAppearanceFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }
    }
}
