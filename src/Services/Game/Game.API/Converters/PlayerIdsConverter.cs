using CountyRP.Services.Game.Infrastructure.Models;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Converters
{
    internal static class PlayerIdsConverter
    {
        public static PersonFilterDtoIn ToPersonFilterWithPlayerIdsRepository(
            IEnumerable<int> source
        )
        {
            return new PersonFilterDtoIn(
                count: null,
                page: null,
                ids: null,
                names: null,
                nameLike: null,
                playerIds: source,
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
