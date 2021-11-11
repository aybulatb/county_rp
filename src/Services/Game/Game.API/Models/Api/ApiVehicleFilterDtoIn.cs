using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiVehicleFilterDtoIn : ApiPagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; init; }

        public IEnumerable<int> Models { get; init; }

        public IEnumerable<int> OwnerIds { get; init; }

        public IEnumerable<string> FactionIds { get; init; }

        public string LicensePlate { get; init; }

        public string LicensePlateLike { get; init; }
    }
}
