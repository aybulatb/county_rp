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
                Count: source.Count,
                Page: source.Page,
                Ids: null,
                Logins: (source.LoginLike == null) ? null : new[] { source.LoginLike },
                StartRegistrationDate: source.StartRegistrationDate,
                FinishRegistrationDate: source.FinishRegistrationDate,
                StartLastVisitDate: source.StartLastVisitGameDate,
                FinishLastVisitDate: source.FinishLastVisitGameDate
            );
        }

        public static GamePersonFilterDtoIn ToGamePersonFilterDtoInService(
            ApiPlayerFilterDtoIn source
        )
        {
            return new GamePersonFilterDtoIn(
                Count: 3,
                Page: 1,
                Ids: null,
                Names: (source.NameLike == null) ? null : new[] { source.NameLike },
                NameLike: source.NameLike,
                PlayerIds: null,
                StartRegistrationDate: null,
                FinishRegistrationDate: null,
                StartLastVisitDate: null,
                FinishLastVisitDate: null,
                AdminLevelIds: null,
                FactionIds: (source.FactionId == null) ? null : new[] { source.FactionId },
                GangIds: null,
                Leader: null,
                Rank: null
            );
        }
    }
}
