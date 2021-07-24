using System;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class EditedPersonDtoIn
    {
        public int Id { get; }

        public string Name { get; }

        public int PlayerId { get; }

        public DateTimeOffset LastVisitDate { get; }

        public string AdminLevelId { get; }

        public string FactionId { get; }

        public int? GangId { get; }

        public bool Leader { get; }

        public int Rank { get; }

        public float[] Position { get; }

        public int CommonInventoryId { get; }

        public int PocketsInventoryId { get; }

        public EditedPersonDtoIn(
            int id,
            string name,
            int playerId,
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
