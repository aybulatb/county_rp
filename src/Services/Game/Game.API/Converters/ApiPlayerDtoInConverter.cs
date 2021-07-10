using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiPlayerDtoInConverter
    {
        public static PlayerDtoIn ToRepository(
            ApiPlayerDtoIn source
        )
        {
            return new PlayerDtoIn(
                login: source.Login,
                password: source.Password,
                registrationDate: source.RegistrationDate,
                lastVisitDate: source.LastVisitDate
            );
        }
    }
}
