using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    internal static class ApiBanFilterDtoInConverter
    {
        public static BanFilterDtoIn ToRepository(
            ApiBanFilterDtoIn source
        )
        {
            return new BanFilterDtoIn(
                Count: source.Count,
                Page: source.Page,
                StartDateTime: source.StartDateTime,
                FinishDateTime: source.FinishDateTime
            );
        }
    }
}
