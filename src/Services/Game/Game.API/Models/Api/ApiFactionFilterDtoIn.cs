using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiFactionFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<string> Ids { get; init; }

        public string IdLike { get; init; }

        public IEnumerable<string> Names { get; init; }

        public string NameLike { get; init; }

        public IEnumerable<ApiFactionTypeDto> Types { get; init; }
    }
}
