using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    internal static class BanDtoOutConverter
    {
        public static BanDao ToDb(
            BanDtoOut source
        )
        {
            return new BanDao(
                id: source.Id,
                userId: source.UserId,
                adminId: source.AdminId,
                startDateTime: source.StartDateTime,
                finishDateTime: source.FinishDateTime,
                ip: source.IP,
                reason: source.Reason
            );
        }

        public static ApiBanDtoOut ToApi(
            BanDtoOut source
        )
        {
            return new ApiBanDtoOut(
                id: source.Id,
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
