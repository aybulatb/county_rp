using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;
using System.Linq;

namespace CountyRP.Services.Site.Converters
{
    internal static class PagedFilterResultConverter
    {
        public static ApiPagedFilterResult<ApiUserDtoOut> ToApi(
            PagedFilterResult<UserDtoOut> source
        )
        {
            return new ApiPagedFilterResult<ApiUserDtoOut>(
                allCount: source.AllCount,
                page: source.Page,
                maxPages: source.MaxPages,
                items: source.Items.Select(UserDtoOutConverter.ToApi)
            );
        }
    }
}
