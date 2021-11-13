using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using System.Collections.Generic;

namespace CountyRP.Services.Game.API.Converters
{
    internal static class ApiPlayerWithPersonsFilterDtoInConverter
    {
        public static PlayerFilterDtoIn ToPlayerFilterRepository(
            ApiPlayerWithPersonsFilterDtoIn source
        )
        {
            return new PlayerFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                logins: source.Logins,
                partOfLogin: source.PartOfLogin,
                startRegistrationDate: source.StartRegistrationDate,
                finishRegistrationDate: source.FinishRegistrationDate,
                startLastVisitDate: source.StartLastVisitDate,
                finishLastVisitDate: source.FinishLastVisitDate
            );
        }

        public static PersonFilterDtoIn ToPersonFilterRepository(
            ApiPlayerWithPersonsFilterDtoIn source
        )
        {
            return new PersonFilterDtoIn(
                count: null,
                page: null,
                ids: source.Ids,
                names: source.PersonsNames,
                nameLike: source.PersonNameLike,
                playerIds: null,
                startRegistrationDate: null,
                finishRegistrationDate: null,
                startLastVisitDate: null,
                finishLastVisitDate: null,
                adminLevelIds: source.AdminLevelIds,
                factionIds: source.FactionIds,
                gangIds: null,
                leader: null,
                rank: null
            );
        }

        public static PersonFilterDtoIn ToPersonFilterWithPlayerIdsRepository(
            ApiPlayerWithPersonsFilterDtoIn source,
            IEnumerable<int> playerIds
        )
        {
            return new PersonFilterDtoIn(
                count: null,
                page: null,
                ids: source.Ids,
                names: source.PersonsNames,
                nameLike: source.PersonNameLike,
                playerIds: playerIds,
                startRegistrationDate: null,
                finishRegistrationDate: null,
                startLastVisitDate: null,
                finishLastVisitDate: null,
                adminLevelIds: source.AdminLevelIds,
                factionIds: source.FactionIds,
                gangIds: null,
                leader: null,
                rank: null
            );
        }
    }
}
