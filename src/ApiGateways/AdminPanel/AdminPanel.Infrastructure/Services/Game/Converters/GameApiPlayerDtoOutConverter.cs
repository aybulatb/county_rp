using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Converters
{
    internal static class GameApiPlayerDtoOutConverter
    {
        public static GamePlayerDtoOut ToService(
            ApiPlayerDtoOut source
        )
        {
            return new GamePlayerDtoOut(
                Id: source.Id,
                Login: source.Login,
                Password: source.Password,
                RegistrationDate: source.RegistrationDate,
                LastVisitDate: source.LastVisitDate
            );
        }
    }
}
