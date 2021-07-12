using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
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
                sortingFlag: source.SortingFlag,
                groupIds: source.GroupIds
            );
        }
    }
}
