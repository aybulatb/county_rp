using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ApiWarningFilterDtoInConverter
    {
        public static WarningFilterDtoIn ToRepository(
            ApiWarningFilterDtoIn source
        )
        {
            return new WarningFilterDtoIn(
                count: source.Count,
                page: source.Page,
                userId: source.UserId
            );
        }
    }
}
