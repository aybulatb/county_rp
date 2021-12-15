using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models.Player;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters.FullUser
{
    internal static class ApiUpdatedFullUserDtoInConverter
    {
        public static GameEditedPlayerDtoIn ToGameService(
            ApiUpdatedFullUserDtoIn source
        )
        {
            return new GameEditedPlayerDtoIn(
                Login: source.Login,
                Password: "123123123",
                LastVisitDate: DateTimeOffset.UtcNow
            );
        }

        public static SiteUserDtoOut ToSiteService(
            ApiUpdatedFullUserDtoIn source,
            SiteUserDtoOut user
        )
        {
            return new SiteUserDtoOut(
                Id: user.Id,
                Login: source.Login,
                Password: user.Password,
                PlayerId: user.PlayerId,
                ForumUserId: user.ForumUserId,
                GroupId: source.GroupId
            );
        }
    }
}
