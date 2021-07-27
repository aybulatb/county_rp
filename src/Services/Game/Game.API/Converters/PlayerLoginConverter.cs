using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class PlayerLoginConverter
    {
        public static PlayerFilterDtoIn ToPlayerFilterDtoIn(
            string source
        )
        {
            return new PlayerFilterDtoIn(
                count: 1,
                page: 1,
                ids: null,
                logins: new[] { source },
                startRegistrationDate: null,
                finishRegistrationDate: null,
                startLastVisitDate: null,
                finishLastVisitDate: null
            );
        }
    }
}
