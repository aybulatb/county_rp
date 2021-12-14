using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models.Player;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Converters.Player
{
    internal static class GameEditedPlayerDtoInConverter
    {
        public static ApiEditedPlayerDtoIn ToExternalApi(
            GameEditedPlayerDtoIn source
        )
        {
            return new ApiEditedPlayerDtoIn
            {
                Login = source.Login,
                Password = source.Password,
                LastVisitDate = source.LastVisitDate
            };
        }
    }
}
