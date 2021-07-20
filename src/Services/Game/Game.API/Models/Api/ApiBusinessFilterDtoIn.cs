using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiBusinessFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }

        public string Name { get; set; }

        public string NameLike { get; set; }

        public IEnumerable<int> OwnerIds { get; set; }

        public IEnumerable<ApiBusinessTypeDto> Types { get; set; }
    }
}
