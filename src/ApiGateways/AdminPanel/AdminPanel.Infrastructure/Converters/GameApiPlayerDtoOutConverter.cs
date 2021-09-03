using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Converters
{
    internal static class GameApiPlayerDtoOutConverter
    {
        public static GamePlayerDtoOut ToService(
            ApiPlayerDtoOut source
        )
        {
            return new GamePlayerDtoOut(
                id: source.Id,
                login: source.Login,
                password: source.Password,
                registrationDate: source.RegistrationDate,
                lastVisitDate: source.LastVisitDate
            );
        }
    }
}
