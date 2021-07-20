using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiTeleportFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }

        public string Name { get; set; }

        public string NameLike { get; set; }

        public IEnumerable<string> FactionIds { get; set; }

        public IEnumerable<int> GangIds { get; set; }

        public IEnumerable<int> RoomIds { get; set; }

        public IEnumerable<int> BusinessIds { get; set; }
    }
}
