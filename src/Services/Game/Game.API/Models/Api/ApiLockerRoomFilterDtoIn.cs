using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiLockerRoomFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }

        public IEnumerable<string> FactionIds { get; set; }
    }
}
