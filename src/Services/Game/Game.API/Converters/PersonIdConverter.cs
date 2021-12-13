using CountyRP.Services.Game.Infrastructure.Models;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Converters
{
    public static class PersonIdConverter
    {
        public static PersonFilterDtoIn ToPersonFilterDtoIn(
            int source
        )
        {
            return new PersonFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                names: null,
                nameLike: null,
                playerIds: null,
                startRegistrationDate: null,
                finishRegistrationDate: null,
                startLastVisitDate: null,
                finishLastVisitDate: null,
                adminLevelIds: null,
                factionIds: null,
                gangIds: null,
                leader: null,
                rank: null
            );
        }

        public static PersonFilterDtoIn ToPersonFilterDtoIn(
            IEnumerable<int> source
        )
        {
            return new PersonFilterDtoIn(
                count: null,
                page: null,
                ids: source,
                names: null,
                nameLike: null,
                playerIds: null,
                startRegistrationDate: null,
                finishRegistrationDate: null,
                startLastVisitDate: null,
                finishLastVisitDate: null,
                adminLevelIds: null,
                factionIds: null,
                gangIds: null,
                leader: null,
                rank: null
            );
        }
    }
}
