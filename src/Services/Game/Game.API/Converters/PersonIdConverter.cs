using CountyRP.Services.Game.Infrastructure.Models;

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
    }
}
