using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
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
