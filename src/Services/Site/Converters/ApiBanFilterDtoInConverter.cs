using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    internal static class ApiBanFilterDtoInConverter
    {
        public static BanFilterDtoIn ToRepository(
            ApiBanFilterDtoIn source
        )
        {
            return new BanFilterDtoIn(
                count: source.Count,
                page: source.Page,
                startDateTime: source.StartDateTime,
                finishDateTime: source.FinishDateTime
            );
        }
    }
}
