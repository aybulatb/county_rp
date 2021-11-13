using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Converters
{
    internal static class ApiPlayerWithPersonsDtoOutConverter
    {
        public static GamePlayerWithPersonsDtoOut ToService(
            ApiPlayerWithPersonsDtoOut source
        )
        {
            return new GamePlayerWithPersonsDtoOut(
                Id: source.Id,
                Login: source.Login,
                Password: source.Password,
                RegistrationDate: source.RegistrationDate,
                LastVisitDate: source.LastVisitDate,
                Persons: source.Persons
                    .Select(GameApiPersonDtoOutConverter.ToService)
            );
        }
    }
}
