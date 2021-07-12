using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class WarningDaoConverter
    {
        public static WarningDtoOut ToRepository(
            WarningDao source
        )
        {
            return new WarningDtoOut(
                id: source.Id,
                userId: source.UserId,
                adminId: source.AdminId,
                dateTime: source.DateTime,
                finishDateTime: source.FinishDateTime,
                action: source.Action,
                text: source.Text
            );
        }
    }
}
