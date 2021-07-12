using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
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
