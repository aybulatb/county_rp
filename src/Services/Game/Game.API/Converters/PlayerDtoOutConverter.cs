using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace CountyRP.Services.Game.API.Converters
{
    public static class PlayerDtoOutConverter
    {
        public static ApiPlayerDtoOut ToApi(
            PlayerDtoOut source
        )
        {
            return new ApiPlayerDtoOut(
                id: source.Id,
                login: source.Login,
                password: source.Password,
                registrationDate: source.RegistrationDate,
                lastVisitDate: source.LastVisitDate
            );
        }

        public static ApiPlayerWithPersonsDtoOut ToApi(
            PlayerDtoOut source,
            IEnumerable<PersonDtoOut> persons
        )
        {
            return new ApiPlayerWithPersonsDtoOut(
                id: source.Id,
                login: source.Login,
                password: source.Password,
                registrationDate: source.RegistrationDate,
                lastVisitDate: source.LastVisitDate,
                persons: persons
                    .Select(PersonDtoOutConverter.ToApi)
            );
        }
    }
}
