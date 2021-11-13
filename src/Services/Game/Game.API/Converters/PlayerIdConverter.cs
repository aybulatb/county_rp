using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    internal static class PlayerIdConverter
    {
        public static PlayerFilterDtoIn ToPlayerFilterDtoIn(
            int source
        )
        {
            return new PlayerFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                logins: null,
                partOfLogin: null,
                startRegistrationDate: null,
                finishRegistrationDate: null,
                startLastVisitDate: null,
                finishLastVisitDate: null
            );
        }

        public static PersonFilterDtoIn ToPersonFilterDtoIn(
            int source
        )
        {
            return new PersonFilterDtoIn(
                count: null,
                page: null,
                ids: null,
                names: null,
                nameLike: null,
                playerIds: new[] { source },
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
