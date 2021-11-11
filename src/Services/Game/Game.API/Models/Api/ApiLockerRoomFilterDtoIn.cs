using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiLockerRoomFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public IEnumerable<string> FactionIds { get; init; }
    }
}
