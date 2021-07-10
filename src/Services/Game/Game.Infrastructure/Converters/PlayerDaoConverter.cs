using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class PlayerDaoConverter
    {
        public static PlayerDtoOut ToRepository(
            PlayerDao source
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
