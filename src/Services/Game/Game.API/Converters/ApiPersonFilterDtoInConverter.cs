using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiPersonFilterDtoInConverter
    {
        public static PersonFilterDtoIn ToRepository(
            ApiPersonFilterDtoIn source
        )
        {
            return new PersonFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                names: source.Names,
                playerIds: source.PlayerIds,
                startRegistrationDate: source.StartRegistrationDate,
                finishRegistrationDate: source.FinishRegistrationDate,
                startLastVisitDate: source.StartLastVisitDate,
                finishLastVisitDate: source.FinishLastVisitDate,
                adminLevelIds: source.AdminLevelIds,
                factionIds: source.FactionIds,
                gangIds: source.GangIds,
                leader: source.Leader,
                rank: source.Rank
            );
        }
    }
}
