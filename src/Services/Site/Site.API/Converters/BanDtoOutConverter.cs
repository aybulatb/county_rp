using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    internal static class BanDtoOutConverter
    {
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
