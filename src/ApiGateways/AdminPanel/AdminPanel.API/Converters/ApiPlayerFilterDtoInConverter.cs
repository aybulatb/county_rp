using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ApiPlayerFilterDtoInConverter
    {
        public static GamePlayerFilterDtoIn ToGamePlayerFilterDtoInService(
            ApiPlayerFilterDtoIn source
        )
        {
            return new GamePlayerFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: null,
                logins: (source.LoginLike == null) ? null : new[] { source.LoginLike },
                startRegistrationDate: source.StartRegistrationDate,
                finishRegistrationDate: source.FinishRegistrationDate,
                startLastVisitDate: source.StartLastVisitGameDate,
                finishLastVisitDate: source.FinishLastVisitGameDate
            );
        }

        public static GamePersonFilterDtoIn ToGamePersonFilterDtoInService(
            ApiPlayerFilterDtoIn source
        )
        {
            return new GamePersonFilterDtoIn(
                count: 3,
                page: 1,
                ids: null,
                names: (source.NameLike == null) ? null : new[] { source.NameLike },
                playerIds: null,
                startRegistrationDate: null,
                finishRegistrationDate: null,
                startLastVisitDate: null,
                finishLastVisitDate: null,
                adminLevelIds: null,
                factionIds: (source.FactionId == null) ? null : new[] { source.FactionId },
                gangIds: null,
                leader: null,
                rank: null
            );
        }
    }
}
