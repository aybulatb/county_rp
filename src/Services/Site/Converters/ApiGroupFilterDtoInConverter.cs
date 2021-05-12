using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    internal static class ApiGroupFilterDtoInConverter
    {
        public static GroupFilterDtoIn ToRepository(
            ApiGroupFilterDtoIn source
        )
        {
            return new GroupFilterDtoIn(
                count: source.Count,
                page: source.Page,
                name: source.Name
            );
        }
    }
}
