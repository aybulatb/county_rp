using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiTeleportFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public string Name { get; init; }

        public string NameLike { get; init; }

        public IEnumerable<string> FactionIds { get; init; }

        public IEnumerable<int> GangIds { get; init; }

        public IEnumerable<int> RoomIds { get; init; }

        public IEnumerable<int> BusinessIds { get; init; }
    }
}
