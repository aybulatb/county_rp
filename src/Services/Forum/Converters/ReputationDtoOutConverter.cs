using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ReputationDtoOutConverter
    {
        public static ReputationDao ToDb(
            ReputationDtoOut source
        )
        {
            return new ReputationDao(
                id: source.Id,
                userId: source.UserId,
                changedByUserId: source.ChangedByUserId,
                dateTime: source.DateTime,
                action: source.Action,
                text: source.Text
            );
        }
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
