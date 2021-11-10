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
                Id: source.Id,
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
