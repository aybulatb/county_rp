using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;

namespace CountyRP.Services.Site.Converters
{
    internal static class BanDaoConverter
    {
        public static BanDtoOut ToRepository(
            BanDao source
        )
        {
            return new BanDtoOut(
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
