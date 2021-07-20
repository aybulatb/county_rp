using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiFactionFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<string> Ids { get; set; }

        public string IdLike { get; set; }

        public IEnumerable<string> Names { get; set; }

        public string NameLike { get; set; }

        public IEnumerable<ApiFactionTypeDto> Types { get; set; }
    }
}
