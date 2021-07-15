using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiPlayerFilterDtoInConverter
    {
        public static PlayerFilterDtoIn ToRepository(
            ApiPlayerFilterDtoIn source
        )
        {
            return new PlayerFilterDtoIn(
                count: source.Count,
                page: source.Page,
                ids: source.Ids,
                logins: source.Logins,
                startRegistrationDate: source.StartRegistrationDate,
                finishRegistrationDate: source.FinishRegistrationDate,
                startLastVisitDate: source.StartLastVisitDate,
                finishLastVisitDate: source.FinishLastVisitDate
            );
        }
    }
}
