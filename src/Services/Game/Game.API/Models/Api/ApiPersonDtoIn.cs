using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiPersonDtoIn
    {
        public string Name { get; set; }

        public int PlayerId { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }

        public DateTimeOffset LastVisitDate { get; set; }

        public string AdminLevelId { get; set; }

        public string FactionId { get; set; }

        public int? GangId { get; set; }

        public bool Leader { get; set; }

        public int Rank { get; set; }

        public float[] Position { get; set; }

        public int CommonInventoryId { get; set; }

        public int PocketsInventoryId { get; set; }
    }
}
