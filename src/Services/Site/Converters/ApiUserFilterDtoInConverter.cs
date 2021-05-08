using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
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
