using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    internal static class ApiUserFilterDtoInConverter
    {
        public static UserFilterDtoIn ToRepository(
            ApiUserFilterDtoIn source
        )
        {
            return new UserFilterDtoIn(
                Count: source.Count,
                Page: source.Page,
                Login: source.Login,
                LoginLike: source.LoginLike,
                GroupIds: source.GroupIds,
                PlayerIds: source.PlayerIds,
                StartRegistrationDate: source.StartRegistrationDate,
                FinishRegistrationDate: source.FinishRegistrationDate,
                StartLastVisitDate: source.StartLastVisitDate,
                FinishLastVisitDate: source.FinishLastVisitDate
            );
        }
    }
}
