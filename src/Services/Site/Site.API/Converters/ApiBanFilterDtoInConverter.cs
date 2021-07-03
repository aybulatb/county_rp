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
                count: source.Count,
                page: source.Page,
                startDateTime: source.StartDateTime,
                finishDateTime: source.FinishDateTime
            );
        }
    }
}
