using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiAdminLevelFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<string> Ids { get; init; }

        public IEnumerable<string> Names { get; init; }

        public string NameLike { get; init; }
    }
}
