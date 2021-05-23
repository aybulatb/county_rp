using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ApiReputationFilterDtoInConverter
    {
        public static ReputationFilterDtoIn ToRepository(
            ApiReputationFilterDtoIn source
        )
        {
            return new ReputationFilterDtoIn(
                count: source.Count,
                page: source.Page,
                userId: source.UserId
            );
        }
    }
}
