using CountyRP.ApiGateways.AdminPanel.Infrastructure.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Converters
{
    public static class ApiPlayerDtoOutConverter
    {
        public static PlayerDtoOut ToService(
            ApiPlayerDtoOut source
        )
        {
            return new PlayerDtoOut(
                id: source.Id,
                login: source.Login,
                password: source.Password,
                registrationDate: source.RegistrationDate,
                lastVisitDate: source.LastVisitDate
            );
        }
    }
}
