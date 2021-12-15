using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Infrastructure.Models.Ban;

namespace CountyRP.Services.Game.Infrastructure.Converters.Ban
{
    internal static class BanDaoConverter
    {
        public static BanDtoOut ToRepository(
            BanDao source
        )
        {
            return new BanDtoOut(
                Id: source.Id,
                PlayerId: source.PlayerId,
                PersonId: source.PersonId,
                AdminId: source.AdminId,
                StartDateTime: source.StartDateTime,
                FinishDateTime: source.FinishDateTime,
                IP: source.IP,
                Reason: source.Reason
            );
        }
    }
}
