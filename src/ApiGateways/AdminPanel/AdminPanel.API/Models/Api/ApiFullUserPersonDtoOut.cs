using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiFullUserPersonDtoOut
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public DateTimeOffset RegistrationDate { get; init; }

        public DateTimeOffset LastVisitDate { get; init; }

        public string AdminLevelId { get; init; }

        public string FactionId { get; init; }

        public int? GangId { get; init; }

        public bool Leader { get; init; }

        public int Rank { get; init; }

        public ApiFullUserPersonDtoOut(
            int id,
            string name,
            DateTimeOffset registrationDate,
            DateTimeOffset lastVisitDate,
            string adminLevelId,
            string factionId,
            int? gangId,
            bool leader,
            int rank
        )
        {
            Id = id;
            Name = name;
            RegistrationDate = registrationDate;
            LastVisitDate = lastVisitDate;
            AdminLevelId = adminLevelId;
            FactionId = factionId;
            GangId = gangId;
            Leader = leader;
            Rank = rank;
        }
    }
}
