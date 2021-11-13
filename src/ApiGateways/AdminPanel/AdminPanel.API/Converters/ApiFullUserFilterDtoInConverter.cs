using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ApiFullUserFilterDtoInConverter
    {
        public static SiteUserFilterDtoIn ToUserService(
            ApiFullUserFilterDtoIn source
        )
        {
            return new SiteUserFilterDtoIn(
                Count: null,
                Page: null,
                Login: null,
                LoginLike: source.LoginLike,
                GroupIds: string.IsNullOrWhiteSpace(source.GroupId)
                    ? null
                    : new[] { source.GroupId },
                PlayerIds: null,
                StartRegistrationDate: source.StartRegistrationDate,
                FinishRegistrationDate: source.FinishRegistrationDate,
                StartLastVisitDate: source.StartLastVisitSiteDate,
                FinishLastVisitDate: source.FinishLastVisitSiteDate
            );
        }

        public static GamePlayerWithPersonsFilterDtoIn ToGameService(
            ApiFullUserFilterDtoIn source,
            IEnumerable<int> playerIds
        )
        {
            return new GamePlayerWithPersonsFilterDtoIn(
                Count: source.Count,
                Page: source.Page,
                Ids: playerIds,
                Logins: null,
                PartOfLogin: source.LoginLike,
                StartRegistrationDate: null,
                FinishRegistrationDate: null,
                StartLastVisitDate: source.StartLastVisitGameDate,
                FinishLastVisitDate: source.FinishLastVisitGameDate,
                PersonsIds: null,
                PersonsNames: null,
                PersonNameLike: source.PersonNameLike,
                AdminLevelIds: null,
                FactionIds: string.IsNullOrWhiteSpace(source.GroupId)
                    ? null
                    : new[] { source.FactionId }
            );
        }
    }
}
