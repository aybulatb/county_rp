using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiPersonDtoOut
    {
        public int Id { get; init; }

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

        public ApiPersonDtoOut(
            int id,
            string name,
            int playerId,
            DateTimeOffset registrationDate,
            DateTimeOffset lastVisitDate,
            string adminLevelId,
            string factionId,
            int? gangId,
            bool leader,
            int rank,
            float[] position,
            int commonInventoryId,
            int pocketsInventoryId
        )
        {
            Id = id;
            Name = name;
            PlayerId = playerId;
            RegistrationDate = registrationDate;
            LastVisitDate = lastVisitDate;
            AdminLevelId = adminLevelId;
            FactionId = factionId;
            GangId = gangId;
            Leader = leader;
            Rank = rank;
            Position = position;
            CommonInventoryId = commonInventoryId;
            PocketsInventoryId = pocketsInventoryId;
        }
    }
}
