using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class WarningDtoOutConverter
    {
        public static WarningDao ToDb(
            WarningDtoOut source
        )
        {
            return new WarningDao(
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
