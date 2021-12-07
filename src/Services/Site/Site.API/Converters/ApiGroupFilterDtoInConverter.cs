using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    internal static class ApiGroupFilterDtoInConverter
    {
        public static GroupFilterDtoIn ToRepository(
            ApiGroupFilterDtoIn source
        )
        {
            return new GroupFilterDtoIn(
                Count: source.Count,
                Page: source.Page,
                Ids: source.Ids,
                Name: source.Name
            );
        }
    }
}
