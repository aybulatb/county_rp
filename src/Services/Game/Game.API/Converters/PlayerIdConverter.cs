using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class PlayerIdConverter
    {
        public static PlayerFilterDtoIn ToPlayerFilterDtoIn(
            int source
        )
        {
            return new PlayerFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { source },
                logins: null,
                startRegistrationDate: null,
                finishRegistrationDate: null,
                startLastVisitDate: null,
                finishLastVisitDate: null
            );
        }
    }
}
