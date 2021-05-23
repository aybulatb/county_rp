using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
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
        public static ApiWarningDtoOut ToApi(
            WarningDtoOut source
        )
        {
            return new ApiWarningDtoOut()
            {
                Id = source.Id,
                UserId = source.UserId,
                AdminId = source.AdminId,
                DateTime = source.DateTime,
                FinishDateTime = source.FinishDateTime,
                Action = source.Action,
                Text = source.Text
            };
        }
    }
}
