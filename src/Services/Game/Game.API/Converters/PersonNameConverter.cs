using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class PersonNameConverter
    {
        public static PersonFilterDtoIn ToPersonFilterDtoIn(
            string source
        )
        {
            return new PersonFilterDtoIn(
                count: 1,
                page: 1,
                ids: null,
                names: new[] { source },
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
