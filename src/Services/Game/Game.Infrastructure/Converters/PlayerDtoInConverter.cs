using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class PlayerDtoInConverter
    {
        public static PlayerDao ToDb(
            PlayerDtoIn source
        )
        {
            return new PlayerDao(
                id: 0,
                login: source.Login,
                password: source.Password,
                registrationDate: source.RegistrationDate,
                lastVisitDate: source.LastVisitDate
            );
        }
    }
}
