using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiGangFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public string Name { get; init; }

        public string NameLike { get; init; }

        public IEnumerable<ApiGangTypeDto> Types { get; init; }
    }
}
