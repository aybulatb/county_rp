using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ReputationDtoOutConverter
    {
        public static ApiReputationDtoOut ToApi(
            ReputationDtoOut source
        )
        {
            return new ApiReputationDtoOut()
            {
                Id = source.Id,
                UserId = source.UserId,
                ChangedByUserId = source.ChangedByUserId,
                DateTime = source.DateTime,
                Action = source.Action,
                Text = source.Text
            };
        }
    }
}
