using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public record VehicleFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public IEnumerable<int> Models { get; }

        public IEnumerable<int> OwnerIds { get; }

        public IEnumerable<string> FactionIds { get; }

        public string LicensePlate { get; }

        public string LicensePlateLike { get; }

        public VehicleFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            IEnumerable<int> models,
            IEnumerable<int> ownerIds,
            IEnumerable<string> factionIds,
            string licensePlate,
            string licensePlateLike
        )
            : base(count, page)
        {
            Ids = ids;
            Models = models;
            OwnerIds = ownerIds;
            FactionIds = factionIds;
            LicensePlate = licensePlate;
            LicensePlateLike = licensePlateLike;
        }
    }
}
