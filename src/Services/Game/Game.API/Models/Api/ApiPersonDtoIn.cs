using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiPersonDtoIn
    {
        public string Name { get; init; }

        public int PlayerId { get; init; }

        public DateTimeOffset RegistrationDate { get; init; }

        public DateTimeOffset LastVisitDate { get; init; }

        public string AdminLevelId { get; init; }

        public string FactionId { get; init; }

        public int? GangId { get; init; }

        public bool Leader { get; init; }

        public int Rank { get; init; }

        public float[] Position { get; init; }

        public int CommonInventoryId { get; init; }

        public int PocketsInventoryId { get; init; }
    }
}
