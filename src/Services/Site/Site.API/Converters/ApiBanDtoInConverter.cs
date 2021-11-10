using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    internal static class ApiBanDtoInConverter
    {
        public static BanDtoIn ToRepository(
            ApiBanDtoIn source
        )
        {
            return new BanDtoIn(
                UserId: source.UserId,
                AdminId: source.AdminId,
                StartDateTime: source.StartDateTime,
                FinishDateTime: source.FinishDateTime,
                IP: source.IP,
                Reason: source.Reason
            );
        }

        public static BanDtoOut ToDtoOut(
           ApiBanDtoIn source,
           int id
        )
        {
            return new BanDtoOut(
                Id: id,
                UserId: source.UserId,
                AdminId: source.AdminId,
                StartDateTime: source.StartDateTime,
                FinishDateTime: source.FinishDateTime,
                IP: source.IP,
                Reason: source.Reason
            );
        }
    }
}
