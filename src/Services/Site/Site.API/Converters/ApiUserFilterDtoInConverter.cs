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
                count: source.Count,
                page: source.Page,
                login: source.Login,
                groupIds: source.GroupIds
            );
        }
    }
}
