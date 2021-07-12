using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class WarningDtoOutConverter
    {
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
