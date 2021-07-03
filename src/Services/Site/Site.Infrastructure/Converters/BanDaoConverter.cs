using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
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
