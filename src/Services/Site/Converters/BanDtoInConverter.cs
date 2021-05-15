using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
{
    internal static class BanDtoInConverter
    {
        public static BanDao ToDb(
            BanDtoIn source
        )
        {
            return new BanDao(
                id: 0,
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
