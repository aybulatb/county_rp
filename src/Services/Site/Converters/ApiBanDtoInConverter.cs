using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    internal static class ApiBanDtoInConverter
    {
        public static BanDtoIn ToRepository(
            ApiBanDtoIn source
        )
        {
            return new BanDtoIn(
                userId: source.UserId,
                adminId: source.AdminId,
                startDateTime: source.StartDateTime,
                finishDateTime: source.FinishDateTime,
                ip: source.IP,
                reason: source.Reason
            );
        }

        public static BanDtoOut ToDtoOut(
           ApiBanDtoIn source,
           int id
        )
        {
            return new BanDtoOut(
                id: id,
                userId: source.UserId,
                adminId: source.AdminId,
                startDateTime: source.StartDateTime,
                finishDateTime: source.FinishDateTime,
                ip: source.IP,
                reason: source.Reason
            );
        }
    }
}
