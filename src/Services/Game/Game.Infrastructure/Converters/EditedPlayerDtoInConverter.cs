using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class EditedPlayerDtoInConverter
    {
        public static PlayerDao ToDb(
            EditedPlayerDtoIn source,
            PlayerDtoOut playerDtoOut
        )
        {
            return new PlayerDao(
                id: source.Id,
                login: source.Login,
                password: source.Password,
                registrationDate: playerDtoOut.RegistrationDate,
                lastVisitDate: source.LastVisitDate
            );
        }
    }
}
