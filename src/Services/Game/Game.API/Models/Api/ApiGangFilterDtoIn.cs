using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiGangFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }

        public string Name { get; set; }

        public string NameLike { get; set; }

        public IEnumerable<ApiGangTypeDto> Types { get; set; }
    }
}
