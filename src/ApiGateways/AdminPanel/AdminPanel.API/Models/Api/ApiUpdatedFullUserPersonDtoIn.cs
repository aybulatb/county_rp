using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public class ApiUpdatedFullUserPersonDtoIn
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string AdminLevelId { get; init; }

        public string FactionId { get; init; }

        public int? GangId { get; init; }

        public bool Leader { get; init; }

        public int Rank { get; init; }

        public ApiUpdatedFullUserPersonDtoIn(
            int id,
            string name,
            string adminLevelId,
            string factionId,
            int? gangId,
            bool leader,
            int rank
        )
        {
            Id = id;
            Name = name;
            AdminLevelId = adminLevelId;
            FactionId = factionId;
            GangId = gangId;
            Leader = leader;
            Rank = rank;
        }
    }
}
