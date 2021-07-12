using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ApiWarningDtoInConverter
    {
        public static WarningDtoIn ToRepository(
            ApiWarningDtoIn source
        )
        {
            return new WarningDtoIn(
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
