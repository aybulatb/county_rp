using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiBusinessFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public string Name { get; init; }

        public string NameLike { get; init; }

        public IEnumerable<int> OwnerIds { get; init; }

        public IEnumerable<ApiBusinessTypeDto> Types { get; init; }
    }
}
