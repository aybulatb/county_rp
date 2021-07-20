using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiAdminLevelFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<string> Ids { get; set; }

        public IEnumerable<string> Names { get; set; }

        public string NameLike { get; set; }
    }
}
