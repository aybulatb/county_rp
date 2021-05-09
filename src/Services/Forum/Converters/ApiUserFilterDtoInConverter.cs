using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
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
