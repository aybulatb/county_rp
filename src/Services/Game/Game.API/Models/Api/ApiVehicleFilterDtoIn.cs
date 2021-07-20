using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiVehicleFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; set; }

        public IEnumerable<int> Models { get; set; }

        public IEnumerable<int> OwnerIds { get; set; }

        public IEnumerable<string> FactionIds { get; set; }

        public string LicensePlate { get; set; }

        public string LicensePlateLike { get; set; }
    }
}
