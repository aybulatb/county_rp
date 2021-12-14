using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models.Player;
using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters.FullUser
{
    internal static class ApiUpdatedFullUserDtoInConverter
    {
        public static GameEditedPlayerDtoIn ToService(
            ApiUpdatedFullUserDtoIn source
        )
        {
            return new GameEditedPlayerDtoIn(
                Login: source.Login,
                Password: "123123123",
                LastVisitDate: DateTimeOffset.UtcNow
            );
        }
    }
}
